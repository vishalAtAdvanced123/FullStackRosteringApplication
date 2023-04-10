using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Entity
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LocationName { get; set; }

        public Location(string locationName) 
        {
            LocationName = locationName;
        }
    }
}
