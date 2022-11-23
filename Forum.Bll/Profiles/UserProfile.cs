using AutoMapper;
using Forum.Common.Dtos.User;
using Forum.Domain.Identity;

namespace Forum.Bll.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
