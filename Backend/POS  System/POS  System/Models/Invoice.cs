using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Invoice_Number { set; get; }
        public double Total_Price { set; get; }
        public DateTime Invoice_Date { set; get; }
        public List<Invoice_Details> Invoice_Details { get; set; }

    }
}
