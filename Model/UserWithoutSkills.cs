using System.ComponentModel.DataAnnotations;

namespace RosteringPractice.Model
{
    public class UserWithoutSkills
    {
    [Required(ErrorMessage = "The UserName is required")]

    public string? UserName { get; set; }
    [Required(ErrorMessage = "The First is required")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Last is required")]
    public string? LastName { get; set; }

    [RegularExpression("[1-9].*", ErrorMessage = "Only Integer value required")]
    public int LocationId { get; set; }

    public int DesignationId { get; set; }
    public int GenderId { get; set; }
    [Required(ErrorMessage = "The UserName is required")]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is Required")]
    public string Password { get; set; } = string.Empty;
  }
}
