using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserCreationDto
    {
        [Required(ErrorMessage ="The Name must be required")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Location { get; set; }
        public int skillId { get; set; }
    }
}
