namespace Forum.Domain
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public List<Section> Sections { get; set; }
    }
}