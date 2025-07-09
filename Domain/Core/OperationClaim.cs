namespace Domain.Core;

public class OperationClaim : Entity<int>
{
    public string Name { get; set; }

    public OperationClaim() => this.Name = string.Empty;

    public OperationClaim(string name) => this.Name = name;

    public OperationClaim(int id, string name)
        : base(id)
    {
        this.Name = name;
    }
}