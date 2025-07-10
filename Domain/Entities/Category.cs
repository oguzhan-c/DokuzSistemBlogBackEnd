using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
    
    public virtual ICollection<Post> Posts { get; set; }
    public virtual Image Image { get; set; }
    
    public Category(int id , string name, Image image ) : base(id)
    {
        Name = name;
        Image = image;
        
    }

    public Category()
    {
        Posts = new HashSet<Post>();
    }
}