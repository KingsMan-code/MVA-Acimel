using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Icms70Model
    {
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int ModBC { get; set; }
        public decimal PRedBC { get; set; }
        public int VBC { get; set; }
        public int PICMS { get; set; }
        public int VICMS { get; set; }
        //public int VbCFCP { get; set; }
        //public int PfCP { get; set; }
        //public int vFCP { get; set; }
        public int ModBCST { get; set; }

        public decimal PMVAST { get; set; }
        public decimal PREDBCST { get; set; }
        public int VBCST { get; set; }
        public int PICMSST { get; set; }
        public decimal VICMSST { get; set; }

        //public decimal VbCFCPST { get; set; }
        //public decimal PfCPST { get; set; }
        //public decimal VfCPST { get; set; }

        public decimal VICMSDeson { get; set; }
        public decimal MotDesICMS { get; set; }
        public decimal IDProduto { get; set; }
    }
}
