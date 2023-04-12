using RosteringPractice.Entity;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserDto
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage ="The Username is Required")]
        public string? UserName { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public int LocationId { get; set; }
        public int DesignationId  { get; set; } 
        public int GenderId { get; set; }
    //public int SkillId { get; set; }
        [Required(ErrorMessage ="The Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="The Password is Required")]
        public string Password { get; set; }= string.Empty;

        //public ICollection<SkillDto> Skill { get; set; } =
        //    new List<SkillDto>();
             
       


        


        

    }
}
