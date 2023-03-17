using Beis.RegisterYourInterest.Data.Repositories;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Beis.RegisterYourInterest.Services
{
    public class RestoreSessionService : IRestoreSessionService
    {
        private readonly ILogger<RestoreSessionService> _logger;
        private readonly IApplicantRepository _applicantRepository;
        private readonly ISessionService _sessionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RestoreSessionService(ILogger<RestoreSessionService> logger, IApplicantRepository applicantRepository, ISessionService sessionService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _applicantRepository = applicantRepository;
            _sessionService = sessionService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result> RestoreSessionFromDb(string emailAddress)
        {
            try
            {
                var user = await _applicantRepository.FindByEmailAddressAsync(emailAddress);
                if (user.IsFailed)
                {
                    _logger.LogError($"The applicant could not be found : {user.Errors.FirstOrDefault()?.Message}");
                    return Result.Fail(user.Errors);
                }
                WebApplicationDto dto;
                if (!_sessionService.TryGet<WebApplicationDto>(nameof(WebApplicationDto), _httpContextAccessor.HttpContext, out dto) || dto == null)
                {
                    dto = new WebApplicationDto();
                }

                dto.ApplicantEmailAddress = user.Value.email_address;
                dto.ApplicantPhoneNumber = user.Value.applicant_phone_number;
                dto.ApplicantName = user.Value.full_name;
                dto.ApplicantRole = user.Value.applicant_role;
                dto.HasFcaNumber = user.Value.has_fca_number;
                dto.CompaniesHouseNumber = user.Value.companies_house_number;
                dto.CompanyHouseResponse = null; //load this form db or requery api if needed.
                dto.FCAFullRegistrationNumber = user.Value.fca_full_registration_number ?? string.Empty;
                dto.HasCompaniesHouseNumber = user.Value.has_fca_number;

                _sessionService.Set(nameof(WebApplicationDto), dto, _httpContextAccessor.HttpContext);

                return Result.Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"The applicant could not be found : {e?.Message}");
                return Result.Fail($"There was a problem restoring the session: {e?.Message}");
            }
        }
    }
}
