namespace Forum.Domain
{
    public class User : BaseEntity
    {
        public string Status { get; set; }
        public string UserName { get; set; }
        public IList<Message> Messages { get; set; }
        public IList<Theme> Themes { get; set; }
        
    }
}
