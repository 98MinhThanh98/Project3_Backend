
namespace Project3.Models;

public partial class Subject
{
    public long Id { get; set; }

    public string? SubjectName { get; set; }

    public int? TotalTime { get; set; }

    public decimal? Price { get; set; }

    public int? IsDelete { get; set; }

    public long? CoursesId { get; set; }

    public long? CreatedId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? UpdateId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Course? Courses { get; set; }
}
