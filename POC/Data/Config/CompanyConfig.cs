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
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.HasData(GetImages());
        }

        private List<Company> GetImages()
        {
            return new List<Company>
            {
                new Company(){ Id = 1, Name = "Company 1"},
                new Company(){ Id = 2, Name = "Company 2"},
                new Company(){ Id = 3, Name = "Company 3"},
                new Company(){ Id = 4, Name = "Company 4"}
            };
        }
    }
}
