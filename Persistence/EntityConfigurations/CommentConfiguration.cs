using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Persistence.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Table configuration
        builder.ToTable("Comments").HasKey(c => c.Id);

        // Properties configuration
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Text).HasColumnName("Text").HasMaxLength(1000).IsRequired();
        builder.Property(c => c.ParentCommentId).HasColumnName("ParentCommentId");
        builder.Property(c => c.PostId).HasColumnName("PostId").IsRequired();
        builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        // Indexes
        builder.HasIndex(c => c.PostId).HasDatabaseName("IX_Comments_PostId");
        builder.HasIndex(c => c.UserId).HasDatabaseName("IX_Comments_UserId");
        builder.HasIndex(c => c.ParentCommentId).HasDatabaseName("IX_Comments_ParentCommentId");
        builder.HasIndex(c => c.CreatedDate).HasDatabaseName("IX_Comments_CreatedDate");

        // Self-referencing relationship for parent-child comments
        builder.HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Comments_Comments_ParentCommentId");

        // Relationships are configured in Post and User configurations

        // Query filters (for soft delete)
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }

    private IEnumerable<Comment> _seeds
    {
        get
        {
            yield return new Comment
            {
                Id = 0,
                Text = "Great article! Clean Architecture has really helped me organize my projects better.",
                CreatedDate = DateTime.UtcNow.AddDays(-8),
                ParentCommentId = null,
                PostId = PostConfiguration.TurkeyPostId,
                UserId = UserConfiguration.UserId,
                
            };

            yield return new Comment
            {
                Id = 1,
                Text = "Thanks for sharing these best practices. The section on performance optimization was particularly helpful.",
                CreatedDate = DateTime.UtcNow.AddDays(-7),
                ParentCommentId = 0,
                PostId = PostConfiguration.TurkeyPostId,
                UserId = UserConfiguration.AuthorId,
            };
            
            yield return new Comment
            {
                Id = 2,
                Text = "Hello. I Love this article.",
                CreatedDate = DateTime.UtcNow,
                ParentCommentId = null,
                PostId = PostConfiguration.CinemaPostId,
                UserId = UserConfiguration.AdminId,
            };
        }
    }
}