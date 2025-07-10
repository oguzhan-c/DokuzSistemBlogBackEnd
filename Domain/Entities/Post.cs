
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Post : Entity<int>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ShortDesc { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    
    public virtual User User { get; set; }
    public virtual Category Category { get; set; }
    
    public virtual ICollection<Image> Images { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }

    public Post(int id, string title, string content, string shortDesc, int userId,int categoryId)
    {
        Title = title; 
        Content = content;
        ShortDesc = shortDesc;
        UserId = userId;
        CategoryId = categoryId;
    }
    
    public Post()
    {
        Images = new HashSet<Image>();
        Comments = new HashSet<Comment>();
    }
}