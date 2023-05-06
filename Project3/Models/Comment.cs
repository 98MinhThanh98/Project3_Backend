
namespace Project3.Models;

public partial class Comment
{
    public long Id { get; set; }

    public string? CommentMsg { get; set; }

    public DateTime? CommentDate { get; set; }

    public long? BlogId { get; set; }

    public long? UserId { get; set; }

    public long? ParentId { get; set; }

    public int? Rate { get; set; }

    public virtual Blog? Blog { get; set; }

    public virtual User? User { get; set; }
}
