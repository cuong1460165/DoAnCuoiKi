using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb_05.Models
{
    public class ProductVM
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string TinyDes { get; set; }
        public string FullDes { get; set; }
        public decimal Price { get; set; }
        public int CatID { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> MaxPrice { get; set; }
        public Nullable<System.DateTime> Expried { get; set; }
        public Nullable<int> f_IDPost { get; set; }
    }
}