using POC_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Models.ViewModels
{
    public class ToysViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Price { get; set; }
        public string Company { get; set; }
    }
}
