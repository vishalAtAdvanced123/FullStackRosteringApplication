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
            int id)
        {
            var user = await _userInfoRepository.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));

        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserCreationDto user)
        {
            var finalUser = _mapper.Map<Users>(user); 
            await _userInfoRepository.AddUsers(finalUser);
            await _userInfoRepository.SaveChangesAsync();

            var finalUserToReturn = _mapper.Map<UserDto>(finalUser);
            return CreatedAtRoute(finalUser, finalUserToReturn);


        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(int UserId,
            UserUpdateDto user)
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

            await _userInfoRepository.DeleteUsers(user);
            await _userInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
