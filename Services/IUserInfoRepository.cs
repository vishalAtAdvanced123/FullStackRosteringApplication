using RosteringPractice.Entity;

namespace RosteringPractice.Services
{
    public interface IUserInfoRepository
    {
        //Users
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<IEnumerable<Users?>> GetUsersAsync(
            int pageNumber , int pageSize);
        Task<Users?> GetUserAsync(int UserId);
        Task AddUsers(Users user);
        Task DeleteUsers(Users user);
        Task<bool> UserExist(int userId);

        //Locations
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location?> GetLocationAsync(int locationId);

        //Gender
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<Gender?> GetGenderAsync(int genderId);
        

        //Designation
        Task<IEnumerable<Designation>> GetDesignationsAsync();
        Task<Designation?> GetDesignationAsync(int designationId);
        
        
        //UserSkills

        Task<IEnumerable<UserSkills>> GetSkillsForUserAsync(int UserId);
        Task<UserSkills?> GetskillAsync(int id,int SkillId);
        Task AddSkills(int userId ,UserSkills skills);
       
        Task DeleteSkills(int id,UserSkills skill);

        //Skills
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetmasterSkillAsync(int SkillId);
        Task<bool> SaveChangesAsync();

        Task<bool> skillExist( int userId ,int skillId);

    }
}
