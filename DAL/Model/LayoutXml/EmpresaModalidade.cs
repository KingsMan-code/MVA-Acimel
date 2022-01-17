using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.LayoutXml
{
    public class EmpresaModalidade
    {
        public string RazaoSocialEmitente { get; set; }
        public string CnpjEmitente { get; set; }
        public string RazaoSocialDestinatario { get; set; }
        public string CnpjDestinatario { get; set; }
        public string TipoNotaFiscal { get; set; } = "-";
    }
}
