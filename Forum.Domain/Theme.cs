namespace Forum.Domain
{
    public class Theme : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatingTime { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public List<Message> Messages { get; set; }
        public List<Section> Sections { get; set; }
    }
}
