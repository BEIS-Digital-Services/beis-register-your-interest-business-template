
namespace Beis.RegisterYourInterest.Models
{
    public class HasFcaNumberViewModel
    {
        [Required(ErrorMessage = "Select yes if the business has a Financial Conduct Authority number")]
        public bool? HasFcaNumber { get; set; }
    }
}