namespace Project3.Entity.Request
{
    public class BlogReq
    {
        public string? title { get; set; }
        public float? categoryId { get; set; }
        public int? pageSize { get; set; }
        public int? pageNumber { get; set; } = 0;
    }
}
