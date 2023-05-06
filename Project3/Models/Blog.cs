
namespace Project3.Models;

public partial class Blog
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Summay { get; set; }

    public long? UsersId { get; set; }

    public long? CategoryId { get; set; }

    public int? IsDelete { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual CategoryBlog? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? Users { get; set; }
}
