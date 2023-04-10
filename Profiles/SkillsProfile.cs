using AutoMapper;

namespace RosteringPractice.Profiles
{
    public class SkillsProfile:Profile
    {
        public SkillsProfile() 
        {
            CreateMap<Entity.UserSkills, Model.SkillDto>();
            CreateMap<Model.SkillCreationDto, Entity.UserSkills>();
            CreateMap<Model.SkillUpdateDto, Entity.UserSkills>();
            
        }
    }
}
