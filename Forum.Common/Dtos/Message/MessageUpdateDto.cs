using System.ComponentModel.DataAnnotations;

namespace Forum.Common.Dtos.Message
{
    public class MessageUpdateDto
    {
        [MinLength(3, ErrorMessage = "Need more symbols")]
        public string Text { get; set; }
        public DateTime CreatingTime { get; set; }

        [Range(0, 9999)]
        public int AuthorId { get; set; }

        [Range(0,9999)]
        public int ThemeId { get; set; }
    }
}
