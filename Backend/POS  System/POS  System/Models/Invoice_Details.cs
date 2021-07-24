using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Models
{
    public class Invoice_Details
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Invoice")]
        public int Invoice_Number { get; set; }
        public double UnitPrice { set; get; }
        public double Total_Payment { set; get; }
        public int TQuantity_PerItem { set; get; }
    }
}
