using AutoMapper;

namespace RosteringPractice.Profiles
{
    public class SkillsProfile:Profile
    {
        public SkillsProfile() 
        {
            CreateMap<Entity.Skills, Model.SkillDto>();
            CreateMap<Model.SkillCreationDto, Entity.Skills>();
            CreateMap<Model.SkillUpdateDto, Entity.Skills>();
            
        }
    }
}
