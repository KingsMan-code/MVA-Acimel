using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Icms20Model
    {
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int ModBC { get; set; }
        public decimal PRedBC { get; set; }
        public decimal VBC { get; set; }
        public decimal PICMS { get; set; }
        public int VICMS { get; set; }
        public int VICMSDeson { get; set; }
        public decimal MotDesICMS { get; set; }
        public decimal IDProduto { get; set; }
    }
}
