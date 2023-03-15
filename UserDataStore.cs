using RosteringPractice.Model;

namespace RosteringPractice
{
    public class UserDataStore
    {
        public List<UserDto> Users { get; set; }
        public static UserDataStore Current { get; } = new UserDataStore();

        public UserDataStore()
        {
            Users = new List<UserDto>()
            {
                new UserDto()
            {
                Id = 1,
                Name = "Vishal Rathod",
                Email= "Vishalanilrathod@gmail.com",
                Password = "Vishal@123",
                Location = "Vadodara",
                Skills = new List<SkillDto>()
                {
                    new SkillDto()
                    {
                        Id = 1,
                        Name = "Angular"
                    },
                    new SkillDto()
                    {
                        Id = 2,
                        Name= ".NET"
                    }
                }
            },
            new UserDto()
            {
                Id = 2,
                Name = "Rahul Parik",
                Email = "rahulparik12@gmail.com",
                Password = "Rahul@123",
                Location = "Vadodara",
                Skills = new List<SkillDto>()
                {
                    new SkillDto()
                    {
                        Id = 3,
                        Name = "Machine Learning"
                    },
                    new SkillDto()
                    {
                        Id = 4,
                        Name= "Web API"
                    }
                }
            },
            new UserDto()
            {
                Id = 3,
                Name = "Shubham Rathod",
                Email = "sdrathod4801@gmail.com",
                Password = "Shubham@123",
                Location = "Vadodara",
                Skills = new List<SkillDto>()
                {
                    new SkillDto()
                    {
                        Id = 5,
                        Name = "C#"
                    },
                    new SkillDto()
                    {
                        Id = 6,
                        Name= "Python"
                    }
                }
            }
            };
            
        }

    }
}
