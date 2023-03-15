using Beis.Common.Entities;
using Beis.Common.Entities.Interfaces;
using Beis.Common.Entities.Models;
using Beis.RegisterYourInterest.Data;
using Beis.RegisterYourInterest.Data.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Beis.RegisterYourInterest.Extensions
{
    public static class RegisterDbContextsExtenstion
    {
        const string ConnectionStringConfigurationKey = "CONNECTIONSTRING";
        public static void RegisterDbContexts(this WebApplicationBuilder builder)
        {
            var databaseConnectionString = builder.Configuration[ConnectionStringConfigurationKey];
            builder.Services.AddDbContext<RegisterYourInterestDbContext<Applicant>>(options => options.UseNpgsql(databaseConnectionString));
            builder.Services.AddScoped<IBaseUserDbContext<BaseUserEntity>, RegisterYourInterestDbContext<Applicant>>();
            //builder.Services.AddScoped<IBaseUserDbContext<BaseUserEntity>>(x => x.GetService<RegisterYourInterestDbContext<Applicant>>() as IBaseUserDbContext<BaseUserEntity>);
            builder.Services.AddScoped<IFCASocietyDbContext, RegisterYourInterestDbContext<Applicant>>(); 
            builder.Services.AddScoped<ICompanyHouseDbContext, RegisterYourInterestDbContext<Applicant>>();

        }
    }
}
