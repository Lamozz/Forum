namespace Forum.Domain
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public IList<Section> Sections { get; set; }
    }
}