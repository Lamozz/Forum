using System.ComponentModel.DataAnnotations;

namespace Forum.Common.Dtos.Theme
{
    public class ThemeUpdateDto
    {
        [MinLength(3, ErrorMessage = "Need more symbols")]
        [MaxLength(255, ErrorMessage = "So much symbols")]
        public string Title { get; set; }

        [MaxLength(255, ErrorMessage = "So much symbols")]
        public string Description { get; set; }
        public DateTime CreatingTime { get; set; }

        [Range(0, 9999)]
        public int AuthorId { get; set; }

        [Range(0, 9999)]
        public int SectionId { get; set; }
    }
}
