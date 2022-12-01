namespace Forum.Common.Models
{
    public class PaginateRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string ColumnNameForSorting { get; set; }
        public string SortDirection { get; set; }
        public Filter Filter { get; set; }
    }
}
