using Microsoft.AspNetCore.Mvc;

namespace Beis.RegisterYourInterest.Controllers
{
    public class ThankyouController : Controller
    {
        [Route(RoutePaths.ThankYouForYourInterestPage, Name = RouteNames.ThankYouForYourInterestPage)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
