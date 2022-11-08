using AutoMapper;
using Forum.Common.Dtos.Section;
using Forum.Domain;

namespace Forum.Bll.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>();
            CreateMap<SectionUpdateDto, Section>();
        }
    }
}
