using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Entity
{
    public class Skills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("UserId")]
        public Users? Users { get; set; }
        public int UserId { get; set; }
        public Skills(string name)
        {
            Name = name;
        }
    }

}
