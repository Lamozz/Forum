using Forum.Common.Dtos.User;

namespace Forum.Common.Dtos.Message
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatingTime { get; set; }
        public int AuthorId { get; set; }
        public int ThemeId { get; set; }

        public UserDto Author { get; set; }

    }
}
