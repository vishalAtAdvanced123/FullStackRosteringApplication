using AutoMapper;
using RosteringPractice.Entity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RosteringPractice;
using RosteringPractice.Model;
using RosteringPractice.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Cors;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [EnableCors("AllowOrigin")]

    public class UserController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;
        const int MaxPageNumber = 20;


        public UserController(IUserInfoRepository userInfoRepository,
            IMapper mapper)
        {
            _userInfoRepository = userInfoRepository
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(int pageSize, int pageNumber)
        {
            if (pageSize > MaxPageNumber)
            {
                pageSize = MaxPageNumber;
            }
            var userEntities = await _userInfoRepository.GetUsersAsync(pageSize, pageNumber);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userEntities));
            //return Ok(userEntities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(
            int id)
        {
            var user = await _userInfoRepository.GetUserAsync(id);
            if (user == null)
            {
                return NotFound("Please Enter the Valid Value !");
            }

            return Ok(_mapper.Map<UserWithoutSkills>(user));

        }
        [HttpPost]
        public async Task<ActionResult<UserWithoutSkills>> CreateUser(UserCreationDto user)
        {
            var finalUser = _mapper.Map<Users>(user);
            await _userInfoRepository.AddUsers(finalUser);
            await _userInfoRepository.SaveChangesAsync();

            var finalUserToReturn = _mapper.Map<UserWithoutSkills>(finalUser);
            return CreatedAtRoute(finalUser, finalUserToReturn);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserCreationDto user)
        {
            var userForUpdate = await _userInfoRepository.GetUserAsync(id);
            
            if (userForUpdate == null)
            {
                return NotFound("please Enter the valid value");
            }

            


            _mapper.Map(user ,userForUpdate);

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
                return NotFound("Please Enter the Valid Value!");
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
                return NotFound("Please Enter the Valid Value!");
            }

            await _userInfoRepository.DeleteUsers(user);
            await _userInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
