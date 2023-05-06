

namespace Project3.Models;

public partial class CategoryBlog
{
    public long Id { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public long? CreatedId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? UpdateId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
