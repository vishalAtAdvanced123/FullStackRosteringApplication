using Microsoft.EntityFrameworkCore;
using RosteringPractice.Entity;

namespace RosteringPractice.DbContexts
{
    public class UserInfoContext : DbContext
    {
        public DbSet<Users> UsersInfo { get; set; } = null!;
        public DbSet<UserSkills> UserSkills { get; set; } = null!;
        public DbSet<Location> LocationList { get; set; } = null!;
        public DbSet<Gender> GenderList { get; set; } = null!;
        public DbSet<Designation> DesignationList { get; set; } = null!;

        public DbSet<Skill> SkillList { get; set; } = null!;

        public UserInfoContext(DbContextOptions<UserInfoContext>options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasIndex(u => u.UserName).IsUnique();

            modelBuilder.Entity<Users>().HasData(
                new Users("Vishal","Rathod")
                {
                    Id = 1,
                    UserName = "vishal.rathod123",
                    LocationId = 1,
                    DesignationId = 1,
                    GenderId = 1,
                    Email = "Vishalanilrathod@gmail.com",
                    Password = "Vishal@123"
                    


                },
                new Users("Rahul","Parikh")
                {
                    Id = 2,
                    UserName = "rahul.rparikh123",
                    LocationId = 2,
                    DesignationId = 2,
                    GenderId = 1,
                    Email = "rahulparikh12@gmail.com",
                    Password = "Rahul@123",


                },
                new Users("Kiran","Patil")
                {
                    Id = 3,
                    UserName = "Kiran.patil321",
                    LocationId = 3,
                    DesignationId = 2,
                    GenderId = 1,
                    Email = "kirangaudapatil@gmail.com",
                    Password = "Kiran@123",

                });
            modelBuilder.Entity<UserSkills>().HasData(
                new UserSkills()
                {
                    Id = 1,
                    SkillId = 1,
                    UserId = 1


                },
                new UserSkills()
                {
                    Id = 2,
                    SkillId = 2,
                    UserId = 1


                },
                new UserSkills()
                {
                    Id = 3,
                    SkillId = 2,
                    UserId = 1

                },

                new UserSkills()
                {
                    Id = 4,
                    SkillId = 3,
                    UserId = 2
                },
                new UserSkills()
                {
                    Id = 5,
                    SkillId = 4,
                    UserId = 3
                },
                new UserSkills()
                {
                    Id = 6,
                    SkillId = 6,
                    UserId = 3
                }


                );
            modelBuilder.Entity<Location>().HasData(
                new Location("Banglore")
                {
                    Id= 1,
                },
                new Location("Vadodara")
                {
                    Id = 2,
                },
                 new Location("Ahamadabad")
                 {
                     Id = 3,
                 }
                 );

            modelBuilder.Entity<Gender>().HasData(
                new Gender("Male")
                {
                    Id = 1
                },
                new Gender("Female")
                {
                    Id = 2
                }
                );
            modelBuilder.Entity<Designation>().HasData(
               new Designation("Trainee")
               {
                   Id = 1
               },
               new Designation("Jr. Software Developer")
               {
                   Id = 2
               },
               new Designation("Senior Software Developer")
               {
                   Id = 3
               }
               );
            modelBuilder.Entity<Skill>().HasData(
                new Skill("C#")
                {
                    Id= 1
                },
                 new Skill("Angular")
                 {
                     Id = 2
                 },
                 new Skill("Java")
                 {
                     Id = 3
                 },
                 new Skill("Python")
                 {
                     Id = 4
                 },
                 new Skill("Machine Learning")
                 {
                     Id = 5
                 },
                 new Skill("Web API")
                 {
                     Id = 6
                 },
                 new Skill(".NET")
                 {
                     Id = 7
                 }
                );
           


            base.OnModelCreating(modelBuilder);
        }

    }
}
