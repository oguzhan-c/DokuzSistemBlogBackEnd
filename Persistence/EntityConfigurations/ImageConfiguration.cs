using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Persistence.EntityConfigurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        // Table configuration
        builder.ToTable("Images").HasKey(i => i.Id);

        // Properties configuration
        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.FileName).HasColumnName("FileName").HasMaxLength(255).IsRequired();
        builder.Property(i => i.FilePath).HasColumnName("FilePath").HasMaxLength(500).IsRequired();
        builder.Property(i => i.ContentType).HasColumnName("ContentType").HasMaxLength(100).IsRequired();
        builder.Property(i => i.ImageType).HasColumnName("ImageType").IsRequired();
        builder.Property(i => i.DisplayOrder).HasColumnName("DisplayOrder").HasDefaultValue(0);
        builder.Property(i => i.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(i => i.PostId).HasColumnName("PostId"); // This should be nullable
        builder.Property(i => i.CategoryId).HasColumnName("CategoryId"); // This should be nullable
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        // Indexes
        builder.HasIndex(i => i.UserId).HasDatabaseName("IX_Images_UserId");
        builder.HasIndex(i => i.PostId).HasDatabaseName("IX_Images_PostId");
        builder.HasIndex(i => i.CategoryId).HasDatabaseName("IX_Images_CategoryId");
        builder.HasIndex(i => i.ImageType).HasDatabaseName("IX_Images_ImageType");
        builder.HasIndex(i => new { i.PostId, i.DisplayOrder }).HasDatabaseName("IX_Images_PostId_DisplayOrder");
        builder.HasIndex(i => new { i.CategoryId, i.DisplayOrder }).HasDatabaseName("IX_Images_CategoryId_DisplayOrder");

        // Relationships are configured in User, Post, and Category configurations

        // Query filters (for soft delete)
        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}