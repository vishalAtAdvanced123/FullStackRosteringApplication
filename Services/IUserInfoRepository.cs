using RosteringPractice.Entity;

namespace RosteringPractice.Services
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<IEnumerable<Users>> GetUsersAsync(string? name , string? searchQuery);
        Task<Users?> GetUserAsync(int UserId);
        Task<IEnumerable<Skills>> GetSkillsAsync(int userId);
        Task<Skills> GetSkillAsync(int SkillId);
        Task <bool> UserExist(int userId);
        Task AddUsers (Users user);
        Task AddSkills(Skills skills);
        Task DeleteUsers (Users user);
        Task DeleteSkills(Skills skill);
        Task<bool> SaveChangesAsync();

    }
}
