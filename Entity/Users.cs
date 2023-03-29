using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosteringPractice.Entity
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Location { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        

        [ForeignKey("SkillId")]
        public Skills? Skills { get; set; }
        public int SkillId { get; set; }
        public Users(string name)
        {
            Name = name;
        }

    }
}
