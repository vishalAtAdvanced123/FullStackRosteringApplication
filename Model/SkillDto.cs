using System.ComponentModel.DataAnnotations;
namespace RosteringPractice.Model

{
    public class SkillDto
    {
        
        public int Id { get; set; }
        public int SkillId { get; set; }

        public int UserId { get; set; }
        

        //public SkillDto(string name)
        //{
        //    Name = name;
        //}
    }  
}
