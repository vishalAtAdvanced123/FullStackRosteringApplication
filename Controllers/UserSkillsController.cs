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

    public class UserSkillsController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UserSkillsController(IUserInfoRepository userInfoRepository, IMapper mapper) 
        {
            _userInfoRepository = userInfoRepository 
                ?? throw new ArgumentNullException(nameof(userInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkills()
        //{
        //    var skillEntity = await _userInfoRepository.GetSkillsAsync();
        //    return Ok(_mapper.Map<IEnumerable<SkillDto>>(skillEntity));
            
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetForUserSkills(int id)
        {
            if (!await _userInfoRepository.UserExist(id))
            {
                return NotFound();
            }


            var skillEntity = await _userInfoRepository.GetSkillsForUserAsync(id);
            return Ok(_mapper.Map<IEnumerable<SkillDto>>(skillEntity));

        }


        //[HttpGet("{SkillId}")]
        //public async Task<ActionResult<SkillDto>> GetSkill(int SkillId)
        //{
            

        //    var skill = await _userInfoRepository.GetSkillAsync(SkillId);
        //    if (skill == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_mapper.Map<SkillDto>(skill));
            
        //}
        [HttpPost("{id}")]
        public async Task<ActionResult<SkillDto>> CreateSkill(int id,
             SkillCreationDto skill)
        {
            if (!await _userInfoRepository.UserExist(id))
            {
                return NotFound();
            }
            //if (!await _userInfoRepository.skillExist(id, skill.SkillId))
            //{
            //    return BadRequest();
            //}
            
         
                var finalSkill = _mapper.Map<UserSkills>(skill);


                await _userInfoRepository.AddSkills(id, finalSkill);
                await _userInfoRepository.SaveChangesAsync();

                var finalSkillReturn = _mapper.Map<SkillDto>(finalSkill);

                return CreatedAtRoute(finalSkill, finalSkillReturn);

            
            }


        //    [HttpPut]
        //public async Task<ActionResult> SkillUpdate(SkillUpdateDto skill, int SkillId)
        //{
           
        //    var skillentity = await _userInfoRepository.GetskillAsync(SkillId);
        //    if (skillentity == null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(skill , skillentity);
            
        //    await _userInfoRepository.SaveChangesAsync();
            
        //    return NoContent();
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult> SkillDelete( int id ,int SkillId)
        {
            var skillEntity = await _userInfoRepository.GetskillAsync(id, SkillId);
            if (skillEntity == null)
            {
                return NotFound();
            }
            await _userInfoRepository.DeleteSkills(id ,skillEntity);
            await _userInfoRepository.SaveChangesAsync();
            return NoContent();



        }

    }
}
