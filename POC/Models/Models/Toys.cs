using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Models.Models
{
    public class Toys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public int CompanyId { get; set; }
        public decimal Price { get; set; }
        public int ProductImageId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ProductImage ProductImage { get; set; }
    }
}
