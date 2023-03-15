using RosteringPractice.Entity;

namespace RosteringPractice.Model
{
    public class UserDto
    {
       
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; }= string.Empty;

        public string? Location { get; set; }

        public int SkillId { get; set; }


        //public ICollection<SkillDto> Skills { get; set; } = new List<SkillDto>();

    }
}
