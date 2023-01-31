using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(uo => uo.Id);
            builder.Property(uo => uo.Id).HasColumnName("Id");
            builder.Property(uo => uo.UserId).HasColumnName("UserId");
            builder.Property(uo => uo.OperationClaimId).HasColumnName("OperationClaimId");
            builder.HasIndex(uo => new { uo.UserId, uo.OperationClaimId }, "UK_UserOperationClaims_UserId_OperationClaimId").IsUnique();
            builder.HasOne(uo => uo.User);
            builder.HasOne(uo => uo.OperationClaim);
        }
    }
}
