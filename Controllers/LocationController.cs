using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RosteringPractice.Entity;
using RosteringPractice.Model;
using RosteringPractice.Services;

namespace RosteringPractice.Controllers
{
    [Route("api/users/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public LocationController(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locationEntity = await _userInfoRepository.GetLocationsAsync();
            return Ok(_mapper.Map<IEnumerable<Location>>(locationEntity));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _userInfoRepository.GetLocationAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }



    }
}
