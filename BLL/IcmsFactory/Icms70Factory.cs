using DAL.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.IcmsFactory
{
    public class Icms70Factory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> iDictionaryList { get; set; }
  
        IDictionary<string, string> IModalidadeDeIcms.RetornaModalidadeDeIcms(XmlNode node)
        {

            iDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/orig", "0") },
                { "CST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/CST", "0") },
                { "modBc", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/modBc", "0") },
                { "pRedBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pRedBC", "0") },
                { "vBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vBC", "0") },
                { "pICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pICMS", "0") },
                { "vICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vICMS", "0") },
                { "modBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/modBCST", "0") },
                { "pMVAST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pMVAST", "0") },
                { "pRedBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pRedBCST", "0") },
                { "vBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vBCST", "0") },
                { "pICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pICMSST", "0") },
                { "vICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vICMSST", "0") },
                { "vICMSDeson", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vICMSDeson", "0") },
                { "motDesICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/motDesICMS", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS70/vFCPST", "0") }

            };

            return iDictionaryList;
        }
    }
}
