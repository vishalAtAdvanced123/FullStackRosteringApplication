using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Position { get; set; }
        public string? Gender { get; set; }
        public string? Password { get; set; }
        public int skillId { get; set; }
    }
}
