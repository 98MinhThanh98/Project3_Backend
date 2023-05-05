
namespace Project3.Models;

public partial class TestFirst
{
    public long Id { get; set; }

    public string? NameTest { get; set; }

    public long? ScoreTest { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? InfoStudentId { get; set; }

    public virtual InformationStudent? InfoStudent { get; set; }
}
