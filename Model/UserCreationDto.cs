using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserCreationDto
    {

        [Required(ErrorMessage ="The UserName is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "The First is required")]
        [RegularExpression("[a-zA-Z].*", ErrorMessage = "First name must be string")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Last is required")]
        [RegularExpression("[a-zA-Z].*", ErrorMessage = "Last name must be string")]
        public string? LastName { get; set; }

        public int LocationId { get; set; }
        
        public int DesignationId { get; set; }
        public int GenderId { get; set; }

        [Required(ErrorMessage = "The UserName is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; } = string.Empty;

        
        //public int skillId { get; set; }
    }
}
