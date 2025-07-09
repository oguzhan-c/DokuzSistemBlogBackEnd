namespace Domain.Core;

public class UserOperationClaim : Entity<int>
{
    public int UserId { get; set; }

    public int OperationClaimId { get; set; }
    
    public virtual User User { get; set; } = default!;
    public virtual OperationClaim OperationClaim { get; set; } = default!;

    public UserOperationClaim()
    {
        this.UserId = default (int);
        this.OperationClaimId = default (int);
    }

    public UserOperationClaim(int userId, int operationClaimId)
    {
        this.UserId = userId;
        this.OperationClaimId = operationClaimId;
    }

    public UserOperationClaim(int id, int userId, int operationClaimId)
        : base(id)
    {
        this.UserId = userId;
        this.OperationClaimId = operationClaimId;
    }
}