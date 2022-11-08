using AutoMapper;
using Forum.Common.Dtos.Theme;
using Forum.Domain;

namespace Forum.Bll.Profiles
{
    public class ThemeProfile : Profile
    {
        public ThemeProfile()
        {
            CreateMap<Theme, ThemeDto>();
            CreateMap<ThemeUpdateDto, Theme>();
        }
    }
}
