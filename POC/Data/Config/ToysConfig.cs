using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Models.Models;
using System.Collections.Generic;

namespace POC_Data.Config
{
    public class ToysConfig : IEntityTypeConfiguration<Toys>
    {
        public void Configure(EntityTypeBuilder<Toys> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Description).IsRequired(false).HasMaxLength(100);
            builder.Property(t => t.AgeRestriction).HasDefaultValue(true);
            builder.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,6)");

            //TODO:Change this to FK = company
            builder.HasOne(t => t.Company)
                .WithMany(c => c.Toys)
                .HasForeignKey(t => t.CompanyId)
                .IsRequired(true);

            //TODO:Change this to FK = product image
            builder.HasOne(t => t.ProductImage)
                .WithOne(c => c.Toys)
                .HasForeignKey<ProductImage>("ProductImageId")
                .IsRequired(false);

            //TODO:HasData
            builder.HasData(GetToys());
        }

        private List<Toys> GetToys()
        {

            return new List<Toys>()
            {
                new Toys(){Id = 1, Name = "MyToy 1", Description = "This is a toy", CompanyId = 1, AgeRestriction = 5, Price = 15,  ProductImageId = 1},
                new Toys(){Id = 2, Name = "MyToy 2", Description = "This is a toy", CompanyId = 2, AgeRestriction = 5, Price = 15,  ProductImageId = 2},
                new Toys(){Id = 3, Name = "MyToy 3", Description = "This is a toy", CompanyId = 3, AgeRestriction = 5, Price = 15,  ProductImageId = 3},
                new Toys(){Id = 4, Name = "MyToy 4", Description = "This is a toy", CompanyId = 4, AgeRestriction = 5, Price = 15,  ProductImageId = 4}
            };
        }
    }
}
