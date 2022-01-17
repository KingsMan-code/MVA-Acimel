using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSSN101Factory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> iDictionaryList { get; set; }

        public IDictionary<string, string> RetornaModalidadeDeIcms(XmlNode node)
        {

            var _csosn = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/CSOSN", "0");
            var _orig = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/orig", "0");

            
            iDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", _orig },
                { "CST", _orig + _csosn },
                { "pCredSN", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/pCredSN", "0") },
                { "vCredICMSSN", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/vCredICMSSN", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN101/vFCPST", "0") }

            };

            return iDictionaryList;
        }
    }
}