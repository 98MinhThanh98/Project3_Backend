namespace Project3.Entity.Request
{
    public class AddBlogReq
    {
        public long? Id { get; set; }

        public string? Title { get; set; }

        public string? Summay { get; set; }

        public long? UsersId { get; set; }

        public long? CategoryId { get; set; }        
    }
}
