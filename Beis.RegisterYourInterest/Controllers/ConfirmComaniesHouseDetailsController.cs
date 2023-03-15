using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class ConfirmComaniesHouseDetailsController : BaseController<CompaniesHouseNumberViewModel>
    {
        public ConfirmComaniesHouseDetailsController(ILogger<ConfirmComaniesHouseDetailsController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService) : base(logger, httpContextAccessor, sessionService)
        {
        }

        [Route(RoutePaths.ConfirmCompaniesHouseDetailsPage, Name = RouteNames.ConfirmCompaniesHouseDetailsPage)]
        public IActionResult Index()
        {
            var model = base.LoadDtoAndModelFromSession();
            return View(model);
        }

        public override void MapModelToDto(CompaniesHouseNumberViewModel model)
        {
            dto.CompaniesHouseNumber = model.Number;
            dto.CompanyHouseResponse = model.CompanyHouseResponse;
        }

        public override CompaniesHouseNumberViewModel MapDtoToModel(CompaniesHouseNumberViewModel model)
        {
            model.Number = dto.CompaniesHouseNumber;
            model.CompanyHouseResponse = dto.CompanyHouseResponse;
            return model;
        }

 
    }
}
