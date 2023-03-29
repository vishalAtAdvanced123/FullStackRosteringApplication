namespace RosteringPractice.Model
{
    public class UserWithoutSkills
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
        public string? Location { get; set; }

        public string? Position { get; set; }
        public string? Gender { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
