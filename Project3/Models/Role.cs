
namespace Project3.Models;

public partial class Role
{
    public long Id { get; set; }

    public string? NameRole { get; set; }
    public int? IsDelete { get; set; }
    public DateTime? CreateAt { get; set; }  
    public long? CreateId { get; set; }
    public DateTime? UpdateAt { get; set; }
    public long? UpdateId { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
