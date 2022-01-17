using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class RelatoriodosProdutosModel
    {
        public string cEAN { get; set; }
        public string Ncm { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaodeNcm { get; set; }
        public string CstEntrada { get; set; }
        public string CstSaida { get; set; }
        public string Pis { get; set; }
        public string Cofins { get; set; }
        public string Unidade { get; set; }
        public string Fator { get; set; }
    }
}
