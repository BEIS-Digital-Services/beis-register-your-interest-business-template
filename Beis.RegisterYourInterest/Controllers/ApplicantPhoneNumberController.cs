using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class ApplicantPhoneNumberController : BaseController<PhoneNumberViewModel>
    {
        public ApplicantPhoneNumberController(ILogger<ApplicantPhoneNumberController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService) : base(logger, httpContextAccessor, sessionService)
        {
        }

        [HttpGet(RoutePaths.ApplicantPhoneNumberPage, Name = RouteNames.ApplicantPhoneNumberPage)]
        public IActionResult Index()
        {
            var model = base.LoadDtoAndModelFromSession();
            return View(model);
        }

        [HttpPost(RoutePaths.ApplicantPhoneNumberPage, Name = RouteNames.ApplicantPhoneNumberPage)]
        [ValidateAntiForgeryToken]

        public IActionResult Index(PhoneNumberViewModel model)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model.PhoneNumber) || base.StoreDtoAndModelToSession(model).IsFailed) 
            {
                return View("Index", model);
            }

            return RedirectToRoute(RouteNames.ConfirmEmailAddressPage);
        }

        public override PhoneNumberViewModel MapDtoToModel(PhoneNumberViewModel model)
        {
            model.PhoneNumber = dto.ApplicantPhoneNumber;
            return model;
        }

        public override void MapModelToDto(PhoneNumberViewModel model)
        {
            dto.ApplicantPhoneNumber = model.PhoneNumber;
        }
    }
}
