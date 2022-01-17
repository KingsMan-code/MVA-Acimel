using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Icms50Model
    {
        public int ID { get; set; }
        public int Orig { get; set; }
        public int CST { get; set; }
        public int VICMSDeson { get; set; }
        public decimal MotDesICMS { get; set; }
        public decimal IDProduto { get; set; }
    }
}
