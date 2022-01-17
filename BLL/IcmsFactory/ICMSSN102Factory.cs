using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSSN102Factory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> IDictionaryList { get; set; }
        public IDictionary<string, string> RetornaModalidadeDeIcms(XmlNode node)
        {

            var _csosn = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/CSOSN", "0");
            var _orig = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/orig", "0");

            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", _orig },
               { "CST", _orig + _csosn },


                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN102/vFCPST", "0") }
            };

            return IDictionaryList;
        }
    }
}