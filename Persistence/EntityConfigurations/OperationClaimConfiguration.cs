using Application.Features.Auth.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Comments.Constants;
using Application.Features.Images.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.Posts.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int  initialId)
    {
        int  lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Author },
                new() { Id = ++lastId, Name = UsersOperationClaims.User },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Categories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Posts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Comments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CommentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Read },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Write },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Create },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Update },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        #region Images CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ImagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ImagesOperationClaims.Read },
                new() { Id = ++lastId, Name = ImagesOperationClaims.Write },
                new() { Id = ++lastId, Name = ImagesOperationClaims.Create },
                new() { Id = ++lastId, Name = ImagesOperationClaims.Update },
                new() { Id = ++lastId, Name = ImagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        #region Posts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
