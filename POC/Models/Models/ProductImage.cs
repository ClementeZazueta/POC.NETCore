using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Models.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        public Toys Toys { get; set; }
    }
}
