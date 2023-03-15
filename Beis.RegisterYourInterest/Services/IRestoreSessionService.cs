namespace Beis.RegisterYourInterest.Services
{
    public interface IRestoreSessionService
    {
        Task<Result> RestoreSessionFromDb(string emailAddress);
    }
}