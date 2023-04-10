namespace RosteringPractice.Model
{
    public class UserWithoutSkills
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LocationId { get; set; }
        public int DesignationId { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
