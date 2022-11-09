using Forum.Common.Dtos.Message;
using Forum.Common.Dtos.User;

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
        public UserDto Author { get; set; }
        public IList<MessageDto> Messages { get; set; }

    }
}
