using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ProdutoFinal
    {
        public string Ean { get; set; }
        public string cEAN { get; set; }
        public string Ncm { get; set; }
        public string Descricao { get; set; }
        public string CstEntrada { get; set; }
        public string CstSaida { get; set; }
        public string Pis { get; set; }
        public string Cofins { get; set; }
    }
}
