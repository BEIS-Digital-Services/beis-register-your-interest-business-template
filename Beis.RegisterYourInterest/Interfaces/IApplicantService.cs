namespace Beis.RegisterYourInterest.Interfaces
{
    public interface IApplicantService
    {
        Task AddApplicantToDbAndGenerateVerificatonLink(WebApplicationDto applicant);
    }
}