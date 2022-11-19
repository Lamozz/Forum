using Forum.Domain.Identity;

namespace Forum.Domain
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public DateTime CreatingTime { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}
