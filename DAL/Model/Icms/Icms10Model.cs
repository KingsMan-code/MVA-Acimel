using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Icms10Model
    {
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int ModBC { get; set; }
        public decimal VBc { get; set; }
        public decimal PICMS { get; set; }
        public decimal VICMS { get; set; }
        public int ModBCST { get; set; }
        public int PMVAST { get; set; }
        public decimal PRedBCST { get; set; }
        public decimal VBCST { get; set; }
        public decimal PICMSST { get; set; }
        public decimal VICMSST { get; set; }
        public decimal IDProduto { get; set; }

    }
}
