
namespace Beis.RegisterYourInterest.Models
{
    public class TitleOrRoleViewModel
    {
        [Required(ErrorMessage = "Enter your job title or role in the business")]
        public string BusinessRole { get; set; }
    }
}