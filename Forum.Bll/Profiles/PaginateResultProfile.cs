using AutoMapper;
using Forum.Common.Dtos.Category;
using Forum.Common.Models;
using Forum.Domain;
using Microsoft.Extensions.Hosting;

namespace Forum.Bll.Profiles
{
    public class PaginateResultProfile : Profile
    {
        public PaginateResultProfile()
        {
            CreateMap<PaginateResult<Category>, PaginateResult<CategoryDto>>();
        }
    }
}
