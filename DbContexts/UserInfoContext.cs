using Microsoft.EntityFrameworkCore;
using RosteringPractice.Entity;

namespace RosteringPractice.DbContexts
{
    public class UserInfoContext : DbContext
    {
        public DbSet<Users> UsersInfo { get; set; } = null!;
        public DbSet<Skills> UserSkills { get; set; } = null!;

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
                    Location = "Vadodara",
                    Position = "Developer Trainee",
                    Gender = "Male",
                    Password = "Vishal@123",
                    


                },
                new Users("Rahul Parik")
                {
                    Id = 2,
                    Email = "rahulparik12@gmail.com",
                    Location = "Vadodara",
                    Position = "Seniour Developer Trainee",
                    Gender = "Male",
                    Password = "Vishal@123",
                    
                    
                },
                new Users("Shubham Rathod")
                {
                    Id = 3,
                    Email = "sdrathod4801@gmail.com",
                    Location = "Banglore",
                    Position = "Jr. Software Trainee",
                    Gender = "Male",
                    Password = "Vishal@123",
                    
                });
            modelBuilder.Entity<Skills>().HasData(
                new Skills("C#")
                {
                    Id = 1,
                    UserId= 1
                    
                    
                },
                new Skills("Angular")
                {
                    Id = 2,
                    UserId= 1
                    
                    
                },
                new Skills("Web API")
                {
                    Id = 3,
                    UserId= 2
                    
                }, 
                new Skills("Python")
                {
                    Id = 4,
                    UserId= 2
                },
                new Skills("Java")
                {
                    Id = 5,
                    UserId= 3
                },
                new Skills("Machine Learning")
                {
                    Id = 6,
                    UserId= 3
                }
                

                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
