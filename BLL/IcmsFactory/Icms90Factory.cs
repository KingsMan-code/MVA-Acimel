using DAL.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.IcmsFactory
{
    public class Icms90Factory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> iDictionaryList { get; set; }
 
        IDictionary<string, string> IModalidadeDeIcms.RetornaModalidadeDeIcms(XmlNode node)
        {

            iDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/orig", "0") },
                { "CST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/CST", "0") },
                { "modBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/modBC", "0") },
                { "vBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vBC", "0") },
                { "pRedBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pRedBC", "0") },
                { "pICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pICMS", "0") },
                { "vICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vICMS", "0") },
                { "modBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/modBCST", "0") },
                { "pMVAST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pMVAST", "0") },
                { "pRedBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pRedBCST", "0") },
                { "vBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vBCST", "0") },
                { "pICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pICMSST", "0") },
                { "vICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vICMSST", "0") },
                { "vICMSDeson", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vICMSDeson", "0") },
                { "motDesICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/motDesICMS", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS90/vFCPST", "0") }

            };

            return iDictionaryList;
        }
    }
}
