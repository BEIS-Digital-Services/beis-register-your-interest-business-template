using Beis.Common.Entities.Models;
using Beis.Common.Services.CompanyHouseApi;
using Beis.RegisterYourInterest.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Beis.RegisterYourInterest.Data.Entities
{}
namespace Beis.RegisterYourInterest.Data
{
    //[Table("applicant")]
    public class Applicant : BaseUserEntity
    {
        public bool? has_companies_house_number { get; set; }
        public string companies_house_number { get; set; }
        //public CompaniesHouseResponse? CompanyHouseResponse { get; set; } // todo - maybe remove this this is already done in a seperate service and logs to       public DbSet<companies_house_api_result> companies_house_api_result { get; set; }
        public bool? has_fca_number { get; set; }
        public string? fca_full_registration_number { get; set; }
        
        public string applicant_phone_number { get; set; }
        public string applicant_role { get; set; }
    }
}
