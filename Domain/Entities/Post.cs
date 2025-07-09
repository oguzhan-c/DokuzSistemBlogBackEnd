using Domain.Core;

namespace Domain.Entities;

public class Post : Entity<int>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string ShortDesc { get; set; }
}