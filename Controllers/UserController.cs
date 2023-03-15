using AutoMapper;
using RosteringPractice.Entity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RosteringPractice;
using RosteringPractice.Model;
using RosteringPractice.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UserController(IUserInfoRepository userInfoRepository,
            IMapper mapper)
        {
            _userInfoRepository = userInfoRepository
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWithoutSkills>>> GetUsers()
        {
            var userEntities = await _userInfoRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(
            int id, bool includeSkills = false)
        {
            var user = await _userInfoRepository.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<UserWithoutSkills>(user));


            //var user = UserDataStore.Current.Users
            //    .FirstOrDefault(c => c.Id == id);

            //if (user == null)
            //{
            //    return NotFound();
            //}


        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserCreationDto user)
        {
            var finalUser = _mapper.Map<Users>(user);

            await _userInfoRepository.AddUsers(finalUser);

            await _userInfoRepository.SaveChangesAsync();

            var createdUserToReturn = _mapper.Map<UserDto>(finalUser);

            return CreatedAtRoute(user, createdUserToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(int UserId,
            UserUpdateDto user, bool includeSkills)
        {
            var userForUpdate = await _userInfoRepository.GetUserAsync(UserId);
            if (userForUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(user, userForUpdate);

            await _userInfoRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult> PartialUpdateUser(int UserId,
            JsonPatchDocument<UserUpdateDto> patchDocument)
        {
            var user = await _userInfoRepository.GetUserAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            var userToPatch = _mapper.Map<UserUpdateDto>(user);


            //var UserToPatch = new UserUpdateDto()
            //{
            //    Name = user.Name,
            //    Email = user.Email,
            //    Password = user.Password,
            //    Location = user.Location,
            //};
            patchDocument.ApplyTo(userToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(userToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(userToPatch, user);
            await _userInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{UserId}")]
        public async Task<ActionResult> DeleteUser(int UserId)
        {
            var user = await _userInfoRepository.GetUserAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }

            _userInfoRepository.DeleteUsers(user);
            await _userInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
