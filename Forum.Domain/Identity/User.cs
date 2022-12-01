using Microsoft.AspNetCore.Identity;

namespace Forum.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public IList<Message> Messages { get; set; }
        public IList<Theme> Themes { get; set; }
        public Avatar Avatar { get; set; }
    }
}
