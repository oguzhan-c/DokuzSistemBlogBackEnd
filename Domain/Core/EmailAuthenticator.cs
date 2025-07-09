namespace Domain.Core;

public class EmailAuthenticator : Entity<int>
{
    public int UserId { get; set; }

    public string? ActivationKey { get; set; }

    public bool IsVerified { get; set; }
    
    
    public virtual User User { get; set; } = default!;

    public EmailAuthenticator() => this.UserId = default (int);

    public EmailAuthenticator(int userId, bool isVerified)
    {
        this.UserId = userId;
        this.IsVerified = isVerified;
    }

    public EmailAuthenticator(int id, int userId, bool isVerified)
        : base(id)
    {
        this.UserId = userId;
        this.IsVerified = isVerified;
    }
}