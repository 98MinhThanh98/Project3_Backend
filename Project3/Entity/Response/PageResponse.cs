namespace Project3.Entity.Response
{
    public class PageResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public object? Data { get; set; }

        public PageResponse(object data, int pageNumber, int pageSize, int totalRecords, int totalPage)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            TotalRecords = totalRecords;
            TotalPages = totalPage;
        }

        public PageResponse()
        {
        }
    }
}
