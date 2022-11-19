using Forum.Domain.Identity;

namespace Forum.Domain
{
    public class Theme : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatingTime { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public IList<Message> Messages { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
    }
}
