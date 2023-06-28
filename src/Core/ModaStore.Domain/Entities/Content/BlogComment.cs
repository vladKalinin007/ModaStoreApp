using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Content;

public class BlogComment : BaseEntity
{
    public string CustomerId { get; set; }
    public string StoreId { get; set; }
    public string CommentText { get; set; }
    public string BlogPostTitle { get; set; }
    public string BlogPostId { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}