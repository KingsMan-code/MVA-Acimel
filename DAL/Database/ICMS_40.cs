//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ICMS_40
    {
        public int ID { get; set; }
        public Nullable<int> orig { get; set; }
        public Nullable<int> CST { get; set; }
        public Nullable<decimal> vICMSDeson { get; set; }
        public Nullable<int> motDesICMS { get; set; }
        public Nullable<int> IDProduto { get; set; }
    
        public virtual Produto Produto { get; set; }
    }
}
