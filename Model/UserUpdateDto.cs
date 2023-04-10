using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserUpdateDto
    {
        public string? FirstName { get; set; }
       
        public int LocationId { get; set; }
        public int DesignationId { get; set; }
        public int GenderId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int skillId { get; set; }
    }
}
