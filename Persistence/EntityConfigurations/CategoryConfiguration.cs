
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Table configuration
        builder.ToTable("Categories").HasKey(c => c.Id);

        // Properties configuration
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        // Indexes
        builder.HasIndex(c => c.Name).IsUnique().HasDatabaseName("IX_Categories_Name");
        builder.HasIndex(c => c.CreatedDate).HasDatabaseName("IX_Categories_CreatedDate");

        // Relationships configuration
        
        // Category -> Posts (One-to-Many)
        builder.HasMany(c => c.Posts)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Posts_Categories_CategoryId");

        // Category -> Image (One-to-One) - Category has one featured image
        builder.HasOne(c => c.Image)
            .WithOne(i => i.Category)
            .HasForeignKey<Image>(i => i.CategoryId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Images_Categories_CategoryId");

        builder.HasData(_seeds);

        // Query filters (for soft delete)
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }

    public static int  TravelCategoryId { get; } = 1;
    public static int  TechnologyCategoryId { get; } = 2;
    public static int  ArtCategoryId { get; } = 3;
    private IEnumerable<Category> _seeds
    {
        get
        {
            yield return new Category
            {
                Id = TechnologyCategoryId,
                Name = "Technology",
                CreatedDate = DateTime.UtcNow
            };
            
            yield return new Category
            {
                Id = TravelCategoryId,
                Name = "Travel",
                CreatedDate = DateTime.UtcNow
            };

            yield return new Category
            {
                Id = ArtCategoryId,
                Name = "Art",
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}