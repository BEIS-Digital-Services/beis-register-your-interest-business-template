namespace Beis.RegisterYourInterest.Controllers
{
    public class CompaniesHouseController : BaseController<CompaniesHouseViewModel>
    {
        public CompaniesHouseController(ILogger<CompaniesHouseController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService) : base(logger, httpContextAccessor, sessionService)
        {
        }


        [HttpGet(RoutePaths.HasCompaniesHousePage, Name=RouteNames.HasCompaniesHousePage)]
        public IActionResult Index()
        {
            var viewModel = base.LoadDtoAndModelFromSession();
            return View(viewModel);
        }

        [HttpPost(RoutePaths.HasCompaniesHousePage, Name = RouteNames.HasCompaniesHousePage)]
        public IActionResult Index(CompaniesHouseViewModel model)
        {          
            if (ModelState.IsValid && base.StoreDtoAndModelToSession(model).IsSuccess)
                if (model.HasCompaniesHouseNumber.GetValueOrDefault())
                    return RedirectToRoute(RouteNames.CompaniesHouseNumberPage);
                else
                    return RedirectToRoute(RouteNames.HasFcaNumberPage);
            else
                return View(nameof(Index), model);
        }

        public override CompaniesHouseViewModel MapDtoToModel(CompaniesHouseViewModel model)
        {
            model.HasCompaniesHouseNumber = dto.HasCompaniesHouseNumber;
            return model;
        }

        public override void MapModelToDto(CompaniesHouseViewModel model)
        {
            dto.HasCompaniesHouseNumber = model.HasCompaniesHouseNumber;
        }
    }
}