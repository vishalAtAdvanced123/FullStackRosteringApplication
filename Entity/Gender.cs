using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RosteringPractice.Entity
{
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GenderName { get; set; }

        public Gender(string genderName)
        {
            GenderName = genderName;
        }
    }
}
