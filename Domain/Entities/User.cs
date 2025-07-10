using NArchitecture.Core.Security.Entities;

namespace Domain.Entities;

public class User : User<int>
{

    public virtual ICollection<Image> Images { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = default!;
    public virtual ICollection<Comment> Comments { get; set; } = default!;
    
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;

    public bool IsAuthor { get; set; } = false;
    public string FirstName{ get; set; } = default!;
    public string LastName { get; set; }  = default!;
}