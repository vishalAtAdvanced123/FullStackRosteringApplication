using System.ComponentModel.DataAnnotations;
namespace RosteringPractice.Model

{
    public class SkillDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public SkillDto(string name)
        {
            Name = name;
        }
    }  
}
