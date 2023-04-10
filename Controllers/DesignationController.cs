using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosteringPractice.Entity;
using RosteringPractice.Services;

namespace RosteringPractice.Controllers
{
    [Route("api/user/designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public DesignationController(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designation>>> GetDesignations()
        {
            var genderEntity = await _userInfoRepository.GetDesignationsAsync();
            return Ok(_mapper.Map<IEnumerable<Designation>>(genderEntity));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Designation>> GetGender(int id)
        {
            var gender = await _userInfoRepository.GetDesignationAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return Ok(gender);
        }
    }
}
