using AutoMapper;
using Forum.Common.Dtos.User;
using Forum.Domain;

namespace Forum.Bll.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
