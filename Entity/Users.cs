using Microsoft.EntityFrameworkCore;
using RosteringPractice.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace RosteringPractice.Entity
{
    //[Index(nameof(UserName), IsUnique = true)]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("DesignationId")]
        public Designation? Designation { get; set; }
        public int DesignationId { get; set; }

        [ForeignKey("GenderId")]
        public Gender? Gender{ get; set; } 
        public int GenderId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Users(string firstName,string lastName)
        {
            FirstName= firstName;
            LastName= lastName;
        }



        public ICollection<UserSkills> SkillforUser { get; set; } =
            new List<UserSkills>();


        //[ForeignKey("SkillId")]
        //public Skills? Skills { get; set; }
        //public int SkillId { get; set; }


    }
}
