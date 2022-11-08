namespace Forum.Common.Dtos.Theme
{
    public class ThemeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatingTime { get; set; }
        public int AuthorId { get; set; }
        public int SectionId { get; set; }
    }
}
