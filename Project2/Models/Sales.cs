using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Models
{
    public class Sales
    {
        [Required] public int SalesId { get; set; }
        public int CustomersId { get; set; } 
        public DateOnly? Date { get; set; }
        public int ProductsId { get; set; }
        public int StoresId { get; set; }   
        public List<Products> products { get; set; } = new List<Products>();
        public List<Stores> stores { get; set; } = new List<Stores>();
        public Customers customer { get; set; } = null!;
    }
}
