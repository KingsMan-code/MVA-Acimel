using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Model
{
    public class Icms00Model
    {    
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int ModBC { get; set; }
        public decimal VBc { get; set; }
        public decimal PICMS { get; set; }
        public decimal VICMS { get; set; }
        public decimal IDProduto { get; set; }

    }
}
