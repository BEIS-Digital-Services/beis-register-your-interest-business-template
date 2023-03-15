
using Beis.RegisterYourInterest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Beis.RegisterYourInterest.Infrastructure
{
    public class SessionRequiredActionFilter : IActionFilter
    {
        private readonly ISessionService _sessionService;

        public SessionRequiredActionFilter(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // todo - consider moving this to the common nuget package and injecting the exemptions. the route name and path would need to be considered.
            Type[] exemptions = { typeof(HomeController), typeof(SessionExpiredController) };
            if (exemptions.Contains(context.Controller))
                return;

            if (context.Controller is HomeController
                or SessionExpiredController


                )
            {
                return;
            }

            if (!_sessionService.HasValidSession(context.HttpContext) && context.Controller is Controller controller)
            {
                context.Result = controller.RedirectToRoute(RouteNames.SessionExpiredPage, RoutePaths.SessionExpiredPage);
            }
        }
    }
}