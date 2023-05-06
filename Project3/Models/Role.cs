
namespace Project3.Models;

public partial class Role
{
    public long Id { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
