using Forum.Common.Dtos.Section;

namespace Forum.Bll.Interfaces
{
    public interface ISectionService
    {
        Task<IList<SectionDto>> GetSectionsAsync();
        Task<SectionDto> GetSectionByIdAsync(int id);
        Task<SectionDto> CreateSectionAsync(SectionUpdateDto SectionUpdateDto);
        Task<SectionDto> UpdateSectionAsync(int id, SectionUpdateDto SectionUpdateDto);
        Task DeleteSectionAsync(int id);
    }
}
