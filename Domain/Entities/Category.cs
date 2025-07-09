using Domain.Core;

namespace Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
    
    public virtual ICollection<Post> Posts { get; set; }

    public Category(int id , string name)  : base (id)
    {
        Name = name;
    }

    public Category()
    {
        Posts = new HashSet<Post>();
    }
}