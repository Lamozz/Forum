using Forum.Common.Dtos.Section;

namespace Forum.Common.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<SectionDto> Sections { get; set; }
    }
}
