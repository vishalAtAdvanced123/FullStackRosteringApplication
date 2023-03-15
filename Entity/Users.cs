using RosteringPractice.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RosteringPractice.Entity
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Location { get; set; }
        
        [ForeignKey("SkillId")]
        public Skills? Skills { get; set; }
        public int SkillId { get; set; } 
        
        
        public ICollection<Skills> skills { get; set; } = new List<Skills>();

        public Users(string name)
        {
            Name = name;
        }
    }
}
