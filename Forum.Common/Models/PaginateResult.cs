namespace Forum.Common.Models
{
    public class PaginateResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IList<T> Items { get; set; }
    }
}
