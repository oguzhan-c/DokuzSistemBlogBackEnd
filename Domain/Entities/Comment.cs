using Domain.Core;

namespace Domain.Entities;

public class Comment : Entity<int>
{
    public string Text { get; set; }
    public bool isReplied { get; set; }
    public int? ParentCommentId { get; set; }

    public virtual Comment?  ParentComment { get; set; }
    
    public virtual ICollection<Comment>? Replies { get; set; }
    
    public Comment()
    {
        Replies = new HashSet<Comment>();
    }

    public Comment(int id , string text, bool isReplied, int? parentCommentId) : base(id)
    {
        Text = text;
        isReplied = isReplied;
        ParentCommentId = parentCommentId;
    }
}