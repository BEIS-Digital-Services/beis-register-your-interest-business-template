using Beis.Common.Services.CompanyHouseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;

namespace Beis.RegisterYourInterest.Controllers
{
    public class CompaniesHouseNumberController : BaseController<CompaniesHouseNumberViewModel>
    {
        private readonly ISessionService _sessionService;
        private readonly ICompanyHouseHttpConnection<CompanyHouseResponse> _apiHttpConnection;
        private readonly ICompanyHouseResultService _companyHouseResultService;
       
        public CompaniesHouseNumberController(
            ILogger<CompaniesHouseNumberController> logger, 
            IHttpContextAccessor httpContextAccessor,
            ISessionService sessionService,
            ICompanyHouseHttpConnection<CompanyHouseResponse> apiHttpConnection,
            ICompanyHouseResultService companyHouseResultService
          ) : base(logger, httpContextAccessor, sessionService)
        {
            _sessionService = sessionService;
            _apiHttpConnection = apiHttpConnection;
            _companyHouseResultService = companyHouseResultService;          
        }      

        [HttpGet(RoutePaths.CompaniesHouseNumberPage, Name=RouteNames.CompaniesHouseNumberPage)]
        public IActionResult Index()
        {
            var model = base.LoadDtoAndModelFromSession(); 
            return View(model);
        }


        [HttpPost(RoutePaths.CompaniesHouseNumberPage, Name = RouteNames.CompaniesHouseNumberPage)]
        public async Task<IActionResult> Index(CompaniesHouseNumberViewModel model)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(model.Number) )
            {
                return View(model);
            }

            var companyHouseResponse = _apiHttpConnection.ProcessRequest(model.GetNumber(), ControllerContext.HttpContext);

            model.CompanyHouseResponse = companyHouseResponse;

            if(base.StoreDtoAndModelToSession(model).IsFailed)
            {
                return View(nameof(Index), model);
            }

            switch (companyHouseResponse.HttpStatusCode)
            {
                case HttpStatusCode.OK when companyHouseResponse.CompanyNumber == null:
                    {
                        return View(model);
                    }

                case HttpStatusCode.NotFound:
                    {
                        return View("CompaniesHouseNotFound");
                    }
            }

            if (companyHouseResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                return RedirectToRoute(RouteNames.CompaniesHouseServiceUnavailable);
            }

            
            var result = await _companyHouseResultService.SaveAsync(companyHouseResponse);
            if(result.IsFailed) 
            { 
                _logger.LogError("Failed to log companies house api result to databse : {0}", result.Errors.FirstOrDefault()?.Message);
                // should this be terminal?
            }

            
            return RedirectToRoute(RouteNames.ConfirmCompaniesHouseDetailsPage);                

        }

        [Route(RoutePaths.CompaniesHouseServiceUnavailable, Name = RouteNames.CompaniesHouseServiceUnavailable)]
        public IActionResult ServiceUnavailable()
        {
            return View();
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