
using Beis.Common.Repositories.Interfaces;
using Beis.Common.Services.CompanyHouseApi;

namespace Beis.RegisterYourInterest.Controllers
{
    public class FcaController : BaseController<HasFcaNumberViewModel>
    {    
        public FcaController(ILogger<FcaController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService) : base(logger, httpContextAccessor, sessionService)
        {

        }

        [HttpGet(RoutePaths.HasFcaNumberPage, Name = RouteNames.HasFcaNumberPage)]
        public IActionResult Index()
        {
            var viewModel = base.LoadDtoAndModelFromSession();
            return View(viewModel);
        }

        [HttpPost(RoutePaths.HasFcaNumberPage, Name = RouteNames.HasFcaNumberPage)]
        [AutoValidateAntiforgeryToken]
        public IActionResult Forward(HasFcaNumberViewModel viewModel)
        {

            if (!ModelState.IsValid || viewModel.HasFcaNumber is null || base.StoreDtoAndModelToSession(viewModel).IsFailed)
            {
                return View(nameof(Index), viewModel);
            }


            if (dto.HasFcaNumber ?? false)
            {
                dto.HasCompaniesHouseNumber = null;
                dto.CompaniesHouseNumber = null;
                dto.CompanyHouseResponse = null;
                return RedirectToRoute(RouteNames.FcaNumberPage);
            }

            return RedirectToRoute(RouteNames.IneligiblePage);
        }

        [Route(RoutePaths.IneligiblePage, Name = RouteNames.IneligiblePage)]
        public IActionResult Ineligible()
        {
            return View();
        }

        public override void MapModelToDto(HasFcaNumberViewModel model)
        {
            dto.HasFcaNumber = model.HasFcaNumber;
        }

        public override HasFcaNumberViewModel MapDtoToModel(HasFcaNumberViewModel model)
        {
            model.HasFcaNumber = dto.HasFcaNumber;
            return model;
        }
    }
}