using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class NotaFiscalModel
    {

        public string CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public string cEAN { get; set; }
        public string Ncm { get; set; }
        public string CST { get; set; }
        public string CFOP { get; set; }
        public string Unidade { get; set; }
        public string Quantidade { get; set; }
        public string ValorUnitario { get; set; }
        public string ValorTotal { get; set; }
        public string BaseDeCalculoIcms { get; set; }
        public string ValorIcms { get; set; }
        public string ValorIpi { get; set; }
        public string AliquotaIcms { get; set; }
        public string AliquotaIpi { get; set; }

    }
}
