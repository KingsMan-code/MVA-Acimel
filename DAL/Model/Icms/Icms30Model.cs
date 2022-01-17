using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Icms30Model
    {
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int ModBCST { get; set; }
        public decimal PMVAST { get; set; }
        public decimal PRedBCST { get; set; }
        public decimal VBCST { get; set; }
        public int PICMSST { get; set; }
        public int VICMSST { get; set; }
        public decimal VICMSDeson { get; set; }
        public decimal MotDesICMS { get; set; }
        public decimal IDProduto { get; set; }

    }
}
