using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSSN500Factory : IModalidadeDeIcms
    {
        internal IDictionary<string, string> IDictionaryList { get; set; }
        public IDictionary<string, string> RetornaModalidadeDeIcms(XmlNode node)
        {

            var _csosn = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/CSOSN", "0");
            var _orig = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/orig", "0");

            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", _orig },
               { "CST", _orig + _csosn },
                { "vBCSTRet", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/vBCSTRet", "0") },
                { "vICMSSTRet", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/vICMSSTRet", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN500/vFCPST", "0") }

            };

            return IDictionaryList;
        }
    }
}