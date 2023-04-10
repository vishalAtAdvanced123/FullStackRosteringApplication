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

        //Users
        public async Task<IEnumerable<Users>> GetUsersAsync(int pageSize, int pageNumber)
        {
            if (pageNumber == 0 && pageSize == 0)
            {
                return await GetUsersAsync();
            }
            var collection = _context.UsersInfo as IQueryable<Users>;


            return await collection.OrderBy(c => c.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

        }
        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            return await _context.UsersInfo.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Users?> GetUserAsync(int userId )
        {
            
            return await _context.UsersInfo.Where(c => c.Id == userId).FirstOrDefaultAsync();
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



        //UserSkills
        //public async Task<IEnumerable<UserSkills>> GetSkillsAsync()
        //{
        //    return await _context.UserSkills.OrderBy(c => c.Id).ToListAsync();
        //}

        public async Task<UserSkills?> GetskillAsync( int id ,int skillid)
        {
            return await _context.UserSkills.Where(c=> c.SkillId == skillid && c.UserId ==id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<UserSkills>> GetSkillsForUserAsync(int userId)
        {
            return await _context.UserSkills.Where(c => c.UserId == userId).ToListAsync();
        }
        public async Task DeleteSkills( int id ,UserSkills skill)
        {
            var user = await GetUserAsync(id);
            if (user != null)
            {
                user.SkillforUser.Remove(skill);
            }
            //_context.UserSkills.Remove(skill);
        }
        public async Task AddSkills(int userId, UserSkills skill)
        {
            var user = await GetUserAsync(userId);
            if (user != null)
            {
                user.SkillforUser.Add(skill);
            }
            // _context.UserSkills.Add(skill);


        }



        // Locations
        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.LocationList.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Location?> GetLocationAsync(int locationId)
        {
            return await _context.LocationList.Where(c => c.Id == locationId)
                .FirstOrDefaultAsync();
        }


        //Gender
        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await _context.GenderList.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Gender?> GetGenderAsync(int genderId)
        {
            return await _context.GenderList.Where(c => c.Id == genderId)
                .FirstOrDefaultAsync();
        }

        //Designation
        public async Task<IEnumerable<Designation>> GetDesignationsAsync()
        {
            return await _context.DesignationList.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Designation?> GetDesignationAsync(int designationId)
        {
            return await _context.DesignationList.Where(c => c.Id == designationId)
                .FirstOrDefaultAsync();
        }

        //Skills
        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _context.SkillList.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<Skill?> GetmasterSkillAsync(int skillId)
        {
            return await _context.SkillList.Where(c => c.Id == skillId)
                .FirstOrDefaultAsync();
        }






        


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> skillExist(int userId ,int skillId)
        {
            var user = await GetUserAsync(userId);
            return user != null && user.SkillforUser.Any(skill => skill.SkillId == skillId);
            
        }

    }
}
