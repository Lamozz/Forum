namespace Forum.Domain
{
    public class Section : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<Theme> Themes { get; set; }
    }
}
