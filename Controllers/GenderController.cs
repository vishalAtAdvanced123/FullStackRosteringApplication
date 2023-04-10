using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosteringPractice.Entity;
using RosteringPractice.Services;

namespace RosteringPractice.Controllers
{
    [Route("api/users/gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public GenderController(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            var genderEntity = await _userInfoRepository.GetGendersAsync();
            return Ok(_mapper.Map<IEnumerable<Gender>>(genderEntity));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            var gender = await _userInfoRepository.GetGenderAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return Ok(gender);
        }
    }
}
