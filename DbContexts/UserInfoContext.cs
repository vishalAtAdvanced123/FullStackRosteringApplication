using Microsoft.EntityFrameworkCore;
using RosteringPractice.Entity;

namespace RosteringPractice.DbContexts
{
    public class UserInfoContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Skills> skills { get; set; } = null!;

        public UserInfoContext(DbContextOptions<UserInfoContext>options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users("Vishal Rathod")
                {
                    Id = 1,
                    Email = "Vishalanilrathod@gmail.com",
                    Password = "Vishal@123",
                    Location = "Vadodara",
                    SkillId = 1


                },
                new Users("Rahul Parik")
                {
                    Id = 2,
                    Email = "rahulparik12@gmail.com",
                    Password = "Rahul@123",
                    Location = "Vadodara",
                    SkillId= 2
                    
                },
                new Users("Shubham Rathod")
                {
                    Id = 3,
                    Email = "sdrathod4801@gmail.com",
                    Password = "Shubham@123",
                    Location = "Vadodara",
                    SkillId= 3
                });
            modelBuilder.Entity<Skills>().HasData(
                new Skills("C#")
                {
                    Id = 1,
                    
                    
                },
                new Skills("Angular")
                {
                    Id = 2,
                    
                    
                },
                new Skills("Web API")
                {
                    Id = 3
                    
                }, 
                new Skills("Python")
                {
                    Id = 4
                },
                new Skills("Java")
                {
                    Id = 5
                },
                new Skills("Machine Learning")
                {
                    Id = 6
                }
                

                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
