using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.ViewModels
{
    public class GetAllInvoices
    {
        public int Invoice_Number { get; set; }
        public DateTime Invoice_Date { set; get; }
        public double Total_Price { set; get; }


    }
}
