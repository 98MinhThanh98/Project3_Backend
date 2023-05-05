
namespace Project3.Models;

public partial class InformationStudent
{
    public long Id { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateBirth { get; set; }

    public string? IdCardStudent { get; set; }

    public string? WasBorn { get; set; }

    public string? IdentityCard { get; set; }

    public string? Email { get; set; }

    public DateTime? StartCard { get; set; }

    public DateTime? EndCard { get; set; }

    public string? FromCard { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public string? Status { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<TestFirst> TestFirsts { get; set; } = new List<TestFirst>();
}
