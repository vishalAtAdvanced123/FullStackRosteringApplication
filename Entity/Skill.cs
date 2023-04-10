using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Entity
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string SkillName { get; set; }

        public Skill(string skillName)
        {
            SkillName = skillName;
        }
    }
}
