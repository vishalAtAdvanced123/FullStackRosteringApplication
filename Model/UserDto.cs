using RosteringPractice.Entity;

namespace RosteringPractice.Model
{
    public class UserDto
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }

       
        public int LocationId { get; set; }
        public int DesignationId { get; set; } 
        public int GenderId { get; set; }
        //public int SkillId { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;

        //public ICollection<SkillDto> Skill { get; set; } =
        //    new List<SkillDto>();
             
       


        


        

    }
}
