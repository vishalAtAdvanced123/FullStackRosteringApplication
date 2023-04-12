using FluentValidation;
using RosteringPractice.DbContexts;
using RosteringPractice.Entity;
using RosteringPractice.Model;

namespace RosteringPractice;

public class UserValidation : AbstractValidator<UserCreationDto>
{
  private readonly UserInfoContext _context;

  public UserValidation(UserInfoContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
    RuleFor(w => w.LocationId)
            .Must(locationId => _context.LocationList.Any(location => location.Id == locationId))
            .WithMessage("Location Id does not exist in the Location List");
    RuleFor(w => w.DesignationId)
            .Must(designationId => _context.DesignationList.Any(designation => designation.Id == designationId))
            .WithMessage("Designation Id does not exist in the Designation List");
    RuleFor(w => w.GenderId)
            .Must(genderId => _context.GenderList.Any(gender => gender.Id == genderId))
            .WithMessage("Gender Id does not exist in the Gender List");
  }
}
