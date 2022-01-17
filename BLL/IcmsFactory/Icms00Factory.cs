using DAL.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL
{
    public class Icms00Factory : IModalidadeDeIcms
    {
        internal IDictionary<string, string> IDictionaryList { get; set; }
  
        IDictionary<string, string> IModalidadeDeIcms.RetornaModalidadeDeIcms(XmlNode node)
        {
            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/orig", "0") },
                { "CST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/CST", "0") },
                { "modBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/modBC", "0") },
                { "vBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/vBC", "0") },
                { "pICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/pICMS", "0") },
                { "vICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/vICMS", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS00/vFCPST", "0") },

            };

            return IDictionaryList;
        }
    }
}
