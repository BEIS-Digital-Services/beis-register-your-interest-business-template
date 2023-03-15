
using DataAnnotationsExtensions;

namespace Beis.RegisterYourInterest.Models
{
    public class EmailAddressViewModel
    {
        [Required(ErrorMessage = "Enter your work email address")] 
        [Email( ErrorMessage = "Enter your work email address")]  
        public string EmailAddress { get; set; }
    } 
}