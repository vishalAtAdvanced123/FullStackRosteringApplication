using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RosteringPractice.DbContexts;
using RosteringPractice.Entity;
using RosteringPractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosteringPracticeNUnit.Repository
{
    public class UserInfoRepositoryTest
    {
        private async Task<UserInfoContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<UserInfoContext>()
                .UseInMemoryDatabase(databaseName: "NewRosteringPractice")
                .Options;

            var databaseContext = new UserInfoContext(options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }

        [Test]
        public async Task UserRepo_Add_ReturnBool()
        {
            var user = new Users("Vishal", "Rathod")
            {
                Id = 5,
                UserName = "vishal.rathod123",
                LocationId = 1,
                DesignationId = 1,
                GenderId = 1,
                Email = "Vishalanilrathod@gmail.com",
                Password = "Vishal@123"
            };

            var dbContext = await GetDbContext();
            var userInfoRepository = new UserInfoRepository(dbContext);
            var result = userInfoRepository.AddUsers(user);
            //var responce =await userInfoRepository.GetUsersAsync();

            result.IsCompletedSuccessfully.Should().BeTrue();
            //responce.Should().HaveCount(3);

        }


        [Test]
        public async Task UserRepo_GetById_return_User()
        {
            
            var id = 3;
            var dbContext = await GetDbContext();
            var userInfoRepository = new UserInfoRepository(dbContext);
            var result =await userInfoRepository.GetUserAsync(id);
            result.Should().NotBeNull();
            Assert.AreEqual(id, result.Id);
            //result.Should().BeOfType<Task<Users>>();

        }

        [Test]
        public async Task UserRepo_GetAllUsers_return_Users()
        {
            var dbContext = await GetDbContext();
            var userInfoRepository = new UserInfoRepository(dbContext);
            var result =await userInfoRepository.GetUsersAsync();
            
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
           // result.Should().BeOfType<Task<IEnumerable<Users>>>();

        }
        [Test]
        public async Task UserRepo_Delete_User()
        {
            Users? user = new Users("Vishal", "Rathod")
            {
                Id = 5,
                UserName = "vishal.rathod123",
                LocationId = 1,
                DesignationId = 1,
                GenderId = 1,
                Email = "Vishalanilrathod@gmail.com",
                Password = "Vishal@123"
            };
            var dbContext = await GetDbContext();
            UserInfoRepository? userInfoRepository = new UserInfoRepository(dbContext);

            var result = userInfoRepository.DeleteUsers(user);
            result.IsCompletedSuccessfully.Should().BeTrue();
        }
        [Test]
        public async Task UserExist()
        {
            int id = 3;
            var dbContext = await GetDbContext();
            var userInfoRepository = new UserInfoRepository(dbContext);
            var result = await userInfoRepository.UserExist(id);

            result.Should().BeTrue();
        } 

    }
}
