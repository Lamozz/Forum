using Forum.Domain.Identity;

namespace Forum.Domain
{
    public class Avatar : BaseEntity
    {
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
        public User User { get; set; }
    }
}
