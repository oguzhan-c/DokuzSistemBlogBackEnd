using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityConfigurations;

namespace Persistence.EntityConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // Table configuration
        builder.ToTable("Posts").HasKey(p => p.Id);

        // Properties configuration
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Title).HasColumnName("Title").HasMaxLength(200).IsRequired();
        builder.Property(p => p.Content).HasColumnName("Content").IsRequired();
        builder.Property(p => p.ShortDesc).HasColumnName("ShortDesc").HasMaxLength(500);
        builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        // Indexes
        builder.HasIndex(p => p.UserId).HasDatabaseName("IX_Posts_UserId");
        builder.HasIndex(p => p.CategoryId).HasDatabaseName("IX_Posts_CategoryId");
        builder.HasIndex(p => p.CreatedDate).HasDatabaseName("IX_Posts_CreatedDate");
        builder.HasIndex(p => p.Title).HasDatabaseName("IX_Posts_Title");

        // Relationships are already configured in User and Category configurations

        builder.HasData(_seeds);
        // Query filters (for soft delete)
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }

    public static int  TurkeyPostId { get; } = 1;
    public static int  CinemaPostId { get; } = 2;
    public static int  AIPostId { get; } = 3;
    private IEnumerable<Post> _seeds
    {
        get
        {
            yield return new Post
            {
                Id = TurkeyPostId,
                Title = "Turkey",
                Content = "Turkey",
                ShortDesc = "Turkey",
                CategoryId = CategoryConfiguration.TravelCategoryId,
                UserId = UserConfiguration.AuthorId,
                CreatedDate = DateTime.UtcNow,
            };
            yield return new Post
            {
                Id = CinemaPostId,
                Title = "Cinema",
                Content = "Cinema",
                ShortDesc = "Cinema",
                CategoryId = CategoryConfiguration.ArtCategoryId,
                UserId = UserConfiguration.AuthorId,
                CreatedDate = DateTime.UtcNow,
            };
            
            yield return new Post
            {
                Id = AIPostId,
                Title = "AI",
                Content = "AI",
                ShortDesc = "AI",
                CategoryId = CategoryConfiguration.TechnologyCategoryId,
                UserId = UserConfiguration.AuthorId,
                CreatedDate = DateTime.UtcNow,
            };
        }
    }
}