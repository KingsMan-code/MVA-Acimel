using DAL.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.IcmsFactory
{
    public class Icms20Factory : IModalidadeDeIcms
    {
        internal IDictionary<string, string> iDictionaryList { get; set; }
    
        IDictionary<string, string> IModalidadeDeIcms.RetornaModalidadeDeIcms(XmlNode node)
        {
            iDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/orig", "0") },
                { "CST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/CST", "0") },
                { "modBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/modBC", "0") },
                { "pRedBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/pRedBC", "0") },
                { "vBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/vBC", "0") },
                { "pICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/pICMS", "0") },
                { "vICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/vICMS", "0") },
                { "vICMSDeson", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/vICMSDeson", "0") },
                { "motDesICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS20/motDesICMS", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS10/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS10/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS10/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS10/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS10/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS10/vFCPST", "0") },


            };

            return iDictionaryList;
        }
    }
}
