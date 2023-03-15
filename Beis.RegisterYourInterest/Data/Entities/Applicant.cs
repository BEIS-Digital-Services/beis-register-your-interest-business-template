using Beis.Common.Entities.Models;
using Beis.Common.Services.CompanyHouseApi;
using System.ComponentModel.DataAnnotations.Schema;
namespace Beis.RegisterYourInterest.Data.Entities
{}
namespace Beis.RegisterYourInterest.Data
{
    //[Table("applicant")]
    public class Applicant : BaseUserEntity
    {
        public bool? HasCompaniesHouseNumber { get; set; }
        public string CompaniesHouseNumber { get; set; }
        //public CompanyHouseResponse? CompanyHouseResponse { get; set; }
        public bool? HasFcaNumber { get; set; }
        public string? FCAFullRegistrationNumber { get; set; }
        
        public string ApplicantPhoneNumber { get; set; }
        public string ApplicantRole { get; set; }
    }
}
