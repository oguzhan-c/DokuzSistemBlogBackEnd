using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table configuration
        builder.ToTable("Users").HasKey(u => u.Id);

        // Properties configuration
        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.IsAuthor).HasColumnName("IsAuthor").HasDefaultValue(false);
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        // Indexes
        builder.HasIndex(u => u.Email).IsUnique().HasDatabaseName("IX_Users_Email");
        builder.HasIndex(u => u.IsAuthor).HasDatabaseName("IX_Users_IsAuthor");
        builder.HasIndex(u => u.CreatedDate).HasDatabaseName("IX_Users_CreatedDate");

        // Relationships configuration
        
        // User -> Posts (One-to-Many)
        builder.HasMany(u => u.Posts)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Posts_Users_UserId");

        // User -> Comments (One-to-Many)
        builder.HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Comments_Users_UserId");

        // User -> Images (One-to-Many)
        builder.HasMany(u => u.Images)
               .WithOne(i => i.User)
               .HasForeignKey(i => i.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Images_Users_UserId");

        // User -> UserOperationClaims (One-to-Many)
        builder.HasMany(u => u.UserOperationClaims)
               .WithOne(uoc => uoc.User)
               .HasForeignKey(uoc => uoc.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_UserOperationClaims_Users_UserId");

        // User -> RefreshTokens (One-to-Many)
        builder.HasMany(u => u.RefreshTokens)
               .WithOne(rt => rt.User)
               .HasForeignKey(rt => rt.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_RefreshTokens_Users_UserId");

        // User -> EmailAuthenticators (One-to-Many)
        builder.HasMany(u => u.EmailAuthenticators)
               .WithOne(ea => ea.User)
               .HasForeignKey(ea => ea.UserId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_EmailAuthenticators_Users_UserId");

        // Query filters (for soft delete)
        builder.HasData(_seeds);
        
        // Query filters (for soft delete)
        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        builder.HasBaseType((string)null!);

    }
       
    public static int  AdminId { get; } = 1;
    public static int  AuthorId { get; } = 2;
    public static int  UserId { get; } = 3;
    
    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Tzua7610?!",
                passwordHash: out byte[] adminPasswordHash,
                passwordSalt: out byte[] adminPasswordSalt
            );
            User adminUser =
                new()
                {
                    Id = AdminId,
                    Email = "admin@DokuzSistem.com",
                    PasswordHash = adminPasswordHash,
                    PasswordSalt = adminPasswordSalt,
                    FirstName = "Admin",
                    LastName = "Admin",
                    CreatedDate = DateTime.UtcNow,
                    
                };
            yield return adminUser;
            
            HashingHelper.CreatePasswordHash(
                password: "Tzua7610?!",
                passwordSalt: out byte[] AuthorPasswordSalt,
                passwordHash: out byte[] AuthorPasswordHash
            );

            User authorUser = 
                new()
                {
                    Id = AuthorId,
                    Email = "author@DokuzSistem.com",
                    PasswordHash = AuthorPasswordHash,
                    PasswordSalt = AuthorPasswordSalt,
                    FirstName = "Author",
                    LastName = "Author",
                    IsAuthor = true,
                    CreatedDate = DateTime.UtcNow,
                };
            yield return authorUser;
            
            HashingHelper.CreatePasswordHash(
                password: "Tzua7610?!",
                passwordSalt: out byte[] UserPasswordSalt,
                passwordHash: out byte[] UserPasswordHash
            );

            User regularUser = 
                new()
                {
                    Id = UserId,
                    Email = "user@DokuzSistem.com",
                    PasswordHash = UserPasswordHash,
                    PasswordSalt = UserPasswordSalt,
                    FirstName = "User",
                    LastName = "User",
                    CreatedDate = DateTime.UtcNow,
                    
                };
            yield return regularUser;
        }
    }
}