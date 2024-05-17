using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    public class Stores
    {
        [Required] public int StoresId { get; set; }
        public string? Name { get; set; } 
        public List<Sales> sales { get; set; } = new List<Sales>();

    }
}
