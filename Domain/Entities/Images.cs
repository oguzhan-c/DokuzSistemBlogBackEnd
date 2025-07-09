using Domain.Core;

namespace Domain.Entities;

public class Images : Entity<int>
{
    public string Name  { get; set; }
    public string FilePath { get; set; }
}