using Beis.Common.Models;
using Beis.Common.Repositories.Interfaces;
using Beis.Common.Services.CompanyHouseApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beis.RegisterYourInterest.Controllers
{
    public class FcaNumberController : BaseController<FcaNumberViewModel>
    {
        private readonly IFCASocietyRepository _fcaSocietyRepository;
        private readonly IFCASocietyService _fcaSocietyService;
        public FcaNumberController(ILogger<FcaNumberController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService, IFCASocietyRepository fcaSocietyRepository, IFCASocietyService fcaSocietyService) : base(logger, httpContextAccessor, sessionService)
        {
            _fcaSocietyRepository = fcaSocietyRepository;
            _fcaSocietyService = fcaSocietyService;
        }

        [HttpGet(RoutePaths.FcaNumberPage, Name = RouteNames.FcaNumberPage)]
        public IActionResult Index()
        {
            return View(base.LoadDtoAndModelFromSession());
        }

        [HttpPost(RoutePaths.FcaNumberPage, Name = RouteNames.FcaNumberPage)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(FcaNumberViewModel viewModel)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(viewModel.GetRegistrationNumber()) || base.StoreDtoAndModelToSession(viewModel).IsFailed) 
            {
                ModelState.Clear();
                ModelState.AddModelError("FCAFullRegistrationNumber", "Enter the Financial Conduct Authority Mutuals Public Register number");
                return View(viewModel);
            }

            //TODO: This should be one off ideally run from a stand alone process before fetching from the repo.
            if (await _fcaSocietyRepository.GetFCASocietiesCount() == 0)
            {
                await _fcaSocietyService.LoadFCASocieties();
            }

            var fcaSociety = await _fcaSocietyRepository.GetFCASociety(viewModel.GetRegistrationNumber());

            if (fcaSociety == null)
            {
                return RedirectToRoute(RouteNames.FcaNumberNotFoundPage);
            }

            if (fcaSociety.society_status.Equals("deregistered", StringComparison.CurrentCultureIgnoreCase))
            {
                return RedirectToRoute(RouteNames.FcaNumberDeregisteredPage);
            }

            base.StoreDtoAndModelToSession(viewModel);
            return RedirectToRoute(RouteNames.ConfirmFcaDetailsPage);

        }

        [Route(RoutePaths.ConfirmFcaDetailsPage, Name = RouteNames.ConfirmFcaDetailsPage)]
        public async Task<IActionResult> CheckCompanyDetails() 
        {
            base.LoadDtoAndModelFromSession();
            var model = await _fcaSocietyService.GetSociety(dto.FCAFullRegistrationNumber);
            return View(model);
        }


        [Route(RoutePaths.FcaNumberNotFoundPage, Name = RouteNames.FcaNumberNotFoundPage)]
        public IActionResult FcaNumberNotFound()
        {
            return View();
        }

        [Route(RoutePaths.FcaNumberDeregisteredPage, Name = RouteNames.FcaNumberDeregisteredPage)]
        public IActionResult Deregistered()
        {
            return View();
        }

        public override FcaNumberViewModel MapDtoToModel(FcaNumberViewModel model)
        {
            model.FCAFullRegistrationNumber = dto.FCAFullRegistrationNumber;
            return model;
        }

        public override void MapModelToDto(FcaNumberViewModel model)
        {
            dto.FCAFullRegistrationNumber = model.FCAFullRegistrationNumber;         
        }
    }
}
