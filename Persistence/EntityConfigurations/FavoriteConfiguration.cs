using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorites");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            builder.HasOne(p => p.Product).WithMany(p => p.Favorites).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Brand).WithMany(p => p.Favorites).HasForeignKey(p => p.BrandId);
            builder.HasOne(p => p.User);
        }
    }
}