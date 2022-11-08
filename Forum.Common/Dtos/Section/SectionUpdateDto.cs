using System.ComponentModel.DataAnnotations;

namespace Forum.Common.Dtos.Section
{
    public class SectionUpdateDto
    {
        [MinLength(3, ErrorMessage = "Need more symbols")]
        [MaxLength(255, ErrorMessage = "So much symbols")]
        public string Title { get; set; }

        [MinLength(3, ErrorMessage = "Need more symbols")]
        public string Description { get; set; }

        [Range(0, 9999)]
        public int CategoryId { get; set; }

    }
}
