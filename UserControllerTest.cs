using AutoMapper;
using CityInfo.API.Controllers;
using NUnit.Framework;
using RosteringPractice.Services;

namespace RosteringPractice
{

  [TestFixture]
  public class UserControllerTest
  {

    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IMapper _mapper;

    [Test]
    public void TestUserController()
    {
     var controller = new UserController(_userInfoRepository , _mapper);
      var user = controller.GetUser(id: 1);
      Assert.IsNotNull(user);
    }


  }
}
