using System.ComponentModel.DataAnnotations;

namespace Forum.Common.Dtos.Category
{
    public class CategoryUpdateDto
    {
        [MinLength(1,ErrorMessage = "Need more symbols")]
        [MaxLength(255,ErrorMessage = "So much symbols")]
        public string Title { get; set; }
    }
}
