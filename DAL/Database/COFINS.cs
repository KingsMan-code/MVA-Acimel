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
    
    public partial class COFINS
    {
        public int IdCofins { get; set; }
        public Nullable<int> CST { get; set; }
        public Nullable<decimal> vBC { get; set; }
        public Nullable<decimal> pCOFINS { get; set; }
        public Nullable<decimal> vCOFINS { get; set; }
        public Nullable<int> IdProduto { get; set; }
    
        public virtual Produto Produto { get; set; }
    }
}
