using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Entity
{
    public class UserSkills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        [ForeignKey("SkillId")]
        public Skill? Skill { get; set; }
        public int SkillId { get; set; }

        
        [ForeignKey("UserId")]
        public Users? Users { get; set; }
        public int UserId { get; set; }
        
    }

}
