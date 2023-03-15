using AutoMapper;

namespace RosteringPractice.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<Entity.Users, Model.UserWithoutSkills>();
            CreateMap<Entity.Users , Model.UserDto>();
            CreateMap<Model.UserCreationDto , Entity.Users>();
            CreateMap<Model.UserUpdateDto, Entity.Users>();
            CreateMap<Entity.Users, Model.UserUpdateDto>();
        }

    }
}
