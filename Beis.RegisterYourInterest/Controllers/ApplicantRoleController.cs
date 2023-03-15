namespace Beis.RegisterYourInterest.Controllers
{
    public class ApplicantRoleController : BaseController<TitleOrRoleViewModel>
    {
        public ApplicantRoleController(ILogger<ApplicantRoleController> logger, IHttpContextAccessor httpContextAccessor, ISessionService sessionService) : base(logger, httpContextAccessor, sessionService)
        {
        }

        [HttpGet(RoutePaths.ApplicantRolePage, Name = RouteNames.ApplicantRolePage)]
        public IActionResult Index()
        {
            try
            {
                var model = base.LoadDtoAndModelFromSession();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error serving applicant role page");

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost(RoutePaths.ApplicantRolePage, Name = RouteNames.ApplicantRolePage)]
        [ValidateAntiForgeryToken]

        public IActionResult Index(TitleOrRoleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model.BusinessRole) || base.StoreDtoAndModelToSession(model).IsFailed)
                {
                    return View(nameof(Index), model);
                }

                return RedirectToRoute(RouteNames.ApplicantEmailAddressPage);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error progressing from applicant role page");

                return RedirectToAction("Error", "Home");
            }
        }

        public override TitleOrRoleViewModel MapDtoToModel(TitleOrRoleViewModel model)
        {
            model.BusinessRole = dto.ApplicantRole;
            return model;
        }

        public override void MapModelToDto(TitleOrRoleViewModel model)
        {
            dto.ApplicantRole = model.BusinessRole;
        }
    }
}