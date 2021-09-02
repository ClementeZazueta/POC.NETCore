using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POC_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Data.Config
{
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.Image).IsRequired().HasColumnType("varbinary(max)");
            builder.HasData(GetImages());
        }

        private List<ProductImage> GetImages()
        {
            byte[] img = Enumerable.Repeat((byte) 0x20, 5).ToArray();

            return new List<ProductImage>
            {
                new ProductImage(){ Id = 1, Image = img},
                new ProductImage(){ Id = 2, Image = img},
                new ProductImage(){ Id = 3, Image = img},
                new ProductImage(){ Id = 4, Image = img}
            };
        }
    }
}
