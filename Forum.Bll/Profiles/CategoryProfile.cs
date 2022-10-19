using AutoMapper;
using Forum.Common.Dtos.Category;
using Forum.Domain;

namespace Forum.Bll.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
