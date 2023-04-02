using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserCreationDto
    {
        
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Location { get; set; }
        
        public string? Position { get; set; }
        public string? Gender { get; set; }
        public string Password { get; set; } = string.Empty;
        
        //public int skillId { get; set; }
    }
}
