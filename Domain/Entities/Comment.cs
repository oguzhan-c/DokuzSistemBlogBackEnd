
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Comment : Entity<int>
{
    public string Text { get; set; }
    public int? ParentCommentId { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    
    
    public virtual Comment?  ParentComment { get; set; }
    public virtual Post Post { get; set; }
    public virtual User User { get; set; }
    
    public virtual ICollection<Comment>? Replies { get; set; }
    
    public Comment()
    {
        Replies = new HashSet<Comment>();
    }

    public Comment(int id , string text , int? parentCommentId, int postId , int userId) : base(id)
    {
        Text = text;
        ParentCommentId = parentCommentId;
        PostId = postId;    
        UserId = userId;
    }
}