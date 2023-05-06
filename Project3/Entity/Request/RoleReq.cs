namespace Project3.Entity.Request
{
    public class RoleReq
    {
        public string RoleName { get; set; }
        public int? pageSize { get; set; }
        public int? pageNumber { get; set; } = 0;
    }
}
