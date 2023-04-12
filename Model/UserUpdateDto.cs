using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserUpdateDto
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int LocationId { get; set; }
        public int DesignationId { get; set; }
        public int GenderId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        
    }
}
