using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.ViewModels
{
    public class NewProductModel
    {
        [Key]
        public int Product_ID { set; get; }
        public int Type_ID { set; get; }
        public string Type_Name { set; get; }
        public string Product_Name { set; get; }
        public double Unit_Price { set; get; }
    }
}
