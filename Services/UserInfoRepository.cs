using Microsoft.EntityFrameworkCore;
using RosteringPractice.DbContexts;
using RosteringPractice.Entity;

namespace RosteringPractice.Services
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly UserInfoContext _context;

        public UserInfoRepository(UserInfoContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            return await _context.UsersInfo.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Users?> GetUserAsync(int userId )
        {
            
            return await _context.UsersInfo.Where(c => c.Id ==userId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Skills>> GetSkillsAsync(int SkillId)
        {
            return await _context.UserSkills.OrderBy(c => c.Id == SkillId).ToListAsync();
        }

        public async Task<Skills?> GetSkillAsync(int skillId)
        {
            return await _context.UserSkills
                  .Where( p=> p.Id == skillId)
                  .FirstOrDefaultAsync();
        }
        public async Task<bool> UserExist(int userId)
        {
            return await _context.UsersInfo.AnyAsync(c => c.Id == userId);
        }
        

       public async Task AddUsers(Users user)
        {
            _context.UsersInfo.Add(user);
        }
        public async Task DeleteUsers(Users user)
        {
            _context.UsersInfo.Remove(user);
        }
        public async Task AddSkills(Skills skills)
        {

            _context.UserSkills.Add(skills);
           
            
        }

        public async Task DeleteSkills(Skills skill)
        {
            _context.UserSkills.Remove(skill);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() == 0;
        }

    }
}
