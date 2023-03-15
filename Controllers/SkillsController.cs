using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosteringPractice.Entity;
using RosteringPractice.Model;
using RosteringPractice.Services;

namespace RosteringPractice.Controllers
{
    
    [Route("api/users/Skill")]
    [ApiController]

    public class SkillsController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public SkillsController(IUserInfoRepository userInfoRepository, IMapper mapper) 
        {
            _userInfoRepository = userInfoRepository 
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkills( int UserId)
        {
            if (!await _userInfoRepository.UserExist(UserId))
            {
                return NotFound();
            }


            var skillEntity = await _userInfoRepository.GetSkillsAsync(UserId);
            return Ok(_mapper.Map<IEnumerable<SkillDto>>(skillEntity));
            
        }
        [HttpGet("{SkillId}")]
        public async Task<ActionResult<SkillDto>> GetSkill(int SkillId)
        {
            

            var skill = await _userInfoRepository.GetSkillAsync(SkillId);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SkillDto>(skill));
            
        }
        [HttpPost]
        public async Task<ActionResult<SkillDto>> CreateSkill(
             SkillCreationDto skill)
        {
            
            var finalSkill = _mapper.Map<Skills>(skill);


            await _userInfoRepository.AddSkills(finalSkill);
            await _userInfoRepository.SaveChangesAsync();

            var finalSkillReturn = _mapper.Map<SkillDto>(finalSkill);

            return CreatedAtRoute(finalSkill, finalSkillReturn);
        }
        [HttpPut]
        public async Task<ActionResult> SkillUpdate(SkillUpdateDto skill, int SkillId)
        {
           
            var skillentity = await _userInfoRepository.GetSkillAsync(SkillId);
            if (skillentity == null)
            {
                return NotFound();
            }
            _mapper.Map(skill , skillentity);
            
            await _userInfoRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpDelete("{SkillId}")]
        public async Task<ActionResult> SkillDelete(int SkillId)
        {
            var skillEntity = await _userInfoRepository.GetSkillAsync( SkillId);
            if (skillEntity == null)
            {
                return NotFound();
            }
            await _userInfoRepository.DeleteSkills(skillEntity);
            await _userInfoRepository.SaveChangesAsync();
            return NoContent();



        }

    }
}
