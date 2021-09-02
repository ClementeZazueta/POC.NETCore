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
        public async Task<byte[]> ConvertImageToByteArray(byte[] toByteArray, List<IFormFile> image)
        {
            foreach (var item in image)
            {
                if (item.Length > 0)
                {
                    using var stream = new MemoryStream();
                    await item.CopyToAsync(stream);
                    toByteArray = stream.ToArray();
                }
            }

            return toByteArray;
        }
    }
}
