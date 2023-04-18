using AutoMapper;
using CityInfo.API.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RosteringPractice.Entity;
using RosteringPractice.Model;
using RosteringPractice.Services;
using System.Threading.Tasks;

namespace RosteringPracticeNUnit
{


    [TestFixture]
    public class UserControllerTest
    {
        private UserController _usercontroller;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        private Mock<IUserInfoRepository> _userRepo;
        private Mock<IMapper> _mapperNew;

        [SetUp]
        public void setup()
        {
            _userRepo = new Mock<IUserInfoRepository>();
            _mapperNew = new Mock<IMapper>();
            _usercontroller = new UserController(_userRepo.Object, _mapperNew.Object);
            
        }
        public UserControllerTest() 
        {
             _userInfoRepository = A.Fake<IUserInfoRepository>();
             _mapper = A.Fake<IMapper>();
            _usercontroller = new UserController(_userInfoRepository, _mapper);

        }
       
        
        [Test]
        public async Task UserController_Return_Ok()
        {
            
            var Users = A.Fake<IEnumerable<Users>>();
             //var user = new Mock<UserDto>();
            //var UserList = A.Fake<IEnumerable<UserDto>>();
            //var _userInfoRepository = A.Fake<IUserInfoRepository>();
            //var _mapper = A.Fake<IMapper>();
            //A.CallTo(()=> _userInfoRepository.GetUsersAsync().Returns(Task.FromResult(UserList)));
           A.CallTo(()=> _userInfoRepository.GetUsersAsync()).Returns(Users);

            var controller = new UserController(_userInfoRepository, _mapper);
           // _userinforepository.Setup(x => x.GetUsersAsync(0,0).Returns(new Task<List<UserDto>>(()=> new List<UserDto>())));

            var result =await controller.GetUsers(0,0);

            //var result = ActionResult.Result as OkObjectResult;
            //var ReturnUser = result.Value as IEnumerable<UserDto>;
            //Assert.Equals(7, ReturnUser.Count());

            //result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<UserDto>>));
        }

        [Test]
        public async Task GetUser_return_Ok()
        {
            int UserId = 2;
            var user = A.Fake<Users>();
            //var user = new Mock<Task<Users>>();
            A.CallTo(()=> _userInfoRepository.GetUserAsync(UserId)).Returns(user);
           

            var result = _usercontroller.GetUser(UserId);
            //var ReturnUser = result.Value as IEnumerable<UserDto>;

           
            result.Should().BeOfType<Task<ActionResult>>();
            
        }


    }
}
