namespace Domain.Core;

public class RefreshToken : Entity<int>
{
    public int UserId { get; set; }

    public string Token { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string CreatedByIp { get; set; }

    public DateTime? RevokedDate { get; set; }

    public string? RevokedByIp { get; set; }

    public string? ReplacedByToken { get; set; }

    public string? ReasonRevoked { get; set; }
    
    public virtual User User { get; set; } = default!;
    

    public RefreshToken()
    {
        this.UserId = default (int);
        this.Token = string.Empty;
        this.CreatedByIp = string.Empty;
    }

    public RefreshToken(int userId, string token, DateTime expirationDate, string createdByIp)
    {
        this.UserId = userId;
        this.Token = token;
        this.ExpirationDate = expirationDate;
        this.CreatedByIp = createdByIp;
    }

    public RefreshToken(
        int id,
        int userId,
        string token,
        DateTime expirationDate,
        string createdByIp)
        : base(id)
    {
        this.UserId = userId;
        this.Token = token;
        this.ExpirationDate = expirationDate;
        this.CreatedByIp = createdByIp;
    }
}
