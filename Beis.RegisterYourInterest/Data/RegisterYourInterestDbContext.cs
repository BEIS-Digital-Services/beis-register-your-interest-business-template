using Beis.Common.Entities;
using Beis.Common.Entities.Interfaces;
using Beis.Common.Entities.ModelBuilderExtensions;
using Beis.Common.Entities.Models;
using Beis.RegisterYourInterest.Data;//.Entities;
using Microsoft.EntityFrameworkCore;


namespace Beis.RegisterYourInterest.Data
{
    public class RegisterYourInterestDbContext<TEntity> : BaseUserDbContext<BaseUserEntity>, IFCASocietyDbContext, ICompanyHouseDbContext
    {
        public RegisterYourInterestDbContext() : base()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public RegisterYourInterestDbContext(DbContextOptions options)
                : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<fcasociety> fcasocieties { get; set; }
        public DbSet<companies_house_api_result> companies_house_api_result { get; set; }

        public DbSet<Applicant> applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)          
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddCompaniesHouseApiModels();
            modelBuilder.AddFcaSocietyModel();
        }
    }
}
