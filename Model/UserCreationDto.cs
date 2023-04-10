using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserCreationDto
    {
        
        public string UserName { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }
        
       
        public int LocationId { get; set; }
        
        public int DesignationId { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        //public int skillId { get; set; }
    }
}
