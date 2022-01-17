using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Icms51Model
    {
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int ModBC { get; set; }
        public decimal PRedBC { get; set; }
        public int VBC { get; set; }
        public int PICMS { get; set; }
        public int VICMSOp { get; set; }
        public int PDif { get; set; }
        public decimal VICMSDif { get; set; }
        public decimal VICMS { get; set; }
        public decimal IDProduto { get; set; }
    }
}
