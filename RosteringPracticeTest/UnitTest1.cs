using AutoMapper;
using RosteringPractice.DbContexts;
using RosteringPractice.Services;

namespace RosteringPracticeTest
{
    public class UserControllerTests
    {

        private IUserInfoRepository _userInfoRepository { get; set; } = null!;
        private IMapper _mapper { get; set; } = null!;
        private UserInfoContext _context { get; set; } = null!;

        
        [SetUp]
        public void Setup()
        { 
        }

        
        [Test]
        public async Task GetUser_EqualTestAsync()
        {

            //Assign
            int id = 1;
            int pageSize = 3;
            int pageNumber = 1;
            var user = await _userInfoRepository.GetUserAsync(id);

            //Assert
            //Assert.IsTrue(user.Result)
            Assert.AreEqual(id , user.Id);

        }
    }
}