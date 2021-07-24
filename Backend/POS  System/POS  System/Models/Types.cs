using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System.Models
{
    public class Types
    {
        [Key]
        public int Type_ID { get; set; }
        public string Type_Name { get; set; }

        public List<Products> Products { get; set; }
    }
}
