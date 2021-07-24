using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.ViewModels
{
    public class InvoiceDetailsModel
    {
        public int Invoice_Number { set; get; }
        public DateTime Invoice_Date { set; get; }
        public double Total_Price { set; get; }
        public List<double> Total_Paymant { set; get; }
        public List<int> TQuantity_PerItem { set; get; }
        public List<int> Product_ID { get; set; }
        public List<string> Product_Name { set; get; }
        public List<double> Unit_Price { set; get; }
    }
}
