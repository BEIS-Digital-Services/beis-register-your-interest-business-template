

using Beis.Common.Attributes;

namespace Beis.RegisterYourInterest.Models
{
    public class PhoneNumberViewModel
    {
        [Required(ErrorMessage = "Enter your business telephone number. This could be a landline or mobile")]
        [PhoneNumber(ErrorMessage = "Enter your business telephone number. This could be a landline or mobile")]
        public string PhoneNumber { get; set; }
    }
}
