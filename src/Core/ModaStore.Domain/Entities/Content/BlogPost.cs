using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Content;

public class BlogPost : BaseEntity
{
    public string Title { get; set; }
    public string PictureId { get; set; }
    public string Body { get; set; }
    public string BodyOverview { get; set; }
    public bool AllowComments { get; set; }
    public int CommentCount { get; set; }
    public string Tags { get; set; }
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
    public string MetaKeywords { get; set; }
    public string MetaDescription { get; set; }
    public string MetaTitle { get; set; }
}