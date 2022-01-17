using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSSN201Factory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> IDictionaryList { get; set; }

        public IDictionary<string, string> RetornaModalidadeDeIcms(XmlNode node)
        {

            var _csosn = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/CSOSN", "0");
            var _orig = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/orig", "0");


            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", _orig },
                { "CST", _orig + _csosn },
                { "modBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/modBCST", "0") },
                { "pMVAST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/pMVAST", "0") },
                { "pRedBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/pRedBCST", "0") },
                { "vBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vBCST", "0") },
                { "pICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/pICMSST", "0") },
                { "vICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vICMSST", "0") },
                { "pCredSN", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/pCredSN", "0") },
                { "vCredICMSSN", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vCredICMSSN", "0") },


                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN201/vFCPST", "0") }


            };

            return IDictionaryList;
        }
    }
}