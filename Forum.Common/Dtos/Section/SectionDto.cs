using Forum.Common.Dtos.Theme;

namespace Forum.Common.Dtos.Section
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IList<ThemeDto> Themes { get; set; }
    }
}
