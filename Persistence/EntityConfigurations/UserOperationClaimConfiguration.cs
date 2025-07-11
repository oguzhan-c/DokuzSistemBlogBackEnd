using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Features.Users.Constants;


namespace Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    private IEnumerable<UserOperationClaim> _seeds
    {
        get
        {
            yield return new()
            {
                Id = 1,
                UserId = UserConfiguration.AdminId,
                OperationClaimId = OperationClaimConfiguration.AdminId
            };
            
            //TODO : ADD claim ides after created Db
            // yield return new()
            // {
            //     Id = 2,
            //     UserId = UserConfiguration.UserId,
            //     OperationClaim = UserConfiguration,
            //     
            // };
            // yield return new()
            // {
            //     Id = 3,
            //     UserId = UserConfiguration.UserId,
            //     OperationClaim = UserConfiguration,
            //     
            // };
        }
    }
}