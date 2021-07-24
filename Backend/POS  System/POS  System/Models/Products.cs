using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_ID { set; get; }
        [Required]
        public string Product_Name { set; get; }
        public double Unit_Price { set; get; }
        [ForeignKey("Types")]
        public int Type_ID { get; set; }
        public List<Invoice_Details> Invoice_Details { get; set; }
        public Types Types { get; set; }


    }
}
