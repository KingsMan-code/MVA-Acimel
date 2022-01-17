using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSSTFactory : IModalidadeDeIcms
    {
        internal IDictionary<string, string> IDictionaryList { get; set; }
        public IDictionary<string, string> RetornaModalidadeDeIcms(XmlNode node)
        {
            var _csosn = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/CSOSN", "0");
            var _orig = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/orig", "0");

            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", _orig },
               { "CST", _orig + _csosn },
                { "vBCSTRet", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vBCSTRet", "0") },
                { "vICMSSTRet", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vICMSSTRet", "0") },
                { "vBCSTDest", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vBCSTDest", "0") },
                { "vICMSSTDest", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vICMSSTDest", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSST/vFCPST", "0") }
            };

            return IDictionaryList;
        }
    }
}