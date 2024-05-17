using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    public class Products
    {
        [Required] public int ProductsId { get; set; }
        public string? Name { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public List<Sales> sales { get; set; } = new List<Sales>();
    }
}
