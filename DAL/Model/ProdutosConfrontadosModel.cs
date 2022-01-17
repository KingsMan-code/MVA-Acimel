using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ProdutosConfrontadosModel
    {
        public string cProd { get; set; }
        public string xProd { get; set; }
        public string cEAN { get; set; }
        public string NCM { get; set; }
        public string DescricaoNCM { get; set; }
        public string DescricaoCEST { get; set; }  
        public string CEST { get; set; }
        public string CFOP { get; set; }    
    }
}
