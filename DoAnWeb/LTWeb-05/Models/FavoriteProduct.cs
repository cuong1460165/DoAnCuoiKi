//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LTWeb_05.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FavoriteProduct
    {
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string TinyDes { get; set; }
        public string FullDes { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> CatID { get; set; }
        public Nullable<decimal> MaxPrice { get; set; }
        public Nullable<System.DateTime> Expried { get; set; }
        public Nullable<int> f_IDLike { get; set; }
    }
}
