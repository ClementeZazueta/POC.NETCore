using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Config
{
    public class ToysConfig : IEntityTypeConfiguration<Toys>
    {
        public void Configure(EntityTypeBuilder<Toys> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Description).IsRequired(false).HasMaxLength(100);
            builder.Property(t => t.AgeRestriction).HasDefaultValue(true);
            builder.Property(t => t.Company).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,6)");
            builder.Property(t => t.ProductImage).HasMaxLength(280);
        }
    }
}
