using Beis.Common.Repositories.Interfaces;
using Beis.Common.Repositories;
using Beis.RegisterYourInterest.Data.Repositories;
using Beis.Common.Services;

namespace Beis.RegisterYourInterest.Extensions
{
    public static class RegisterRepositoriesExtension
    {
        public static void RegisterRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IFCASocietyRepository, FCASocietyRepository>();

            builder.Services.AddScoped<ICompanyHouseResultRepository, CompanyHouseResultRepository>();
            builder.Services.AddScoped<IBaseUsersRepository, BaseUsersRepository>();
            builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
            
            builder.Services.AddScoped<IEmailVerificationService, EmailVerificationService>();

        }
    }
}
