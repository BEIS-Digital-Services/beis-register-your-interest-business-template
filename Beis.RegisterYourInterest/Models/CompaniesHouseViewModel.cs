
namespace Beis.RegisterYourInterest.Models
{
    public class CompaniesHouseViewModel
    {
        [Required(ErrorMessage ="You must specify if you have a companies house number.")]
        public bool? HasCompaniesHouseNumber { get; set; }
    }
}