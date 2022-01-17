using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSSN900Factory : IModalidadeDeIcms
    {
        internal IDictionary<string, string> IDictionaryList { get; set; }
        public IDictionary<string, string> RetornaModalidadeDeIcms(XmlNode node)
        {


            var _csosn = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/CSOSN", "0");
            var _orig = Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/orig", "0");


            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", _orig },
               { "CST", _orig + _csosn },
                { "modBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/modBC", "0") },
                { "vBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vBC", "0") },
                { "pRedBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pRedBC", "0") },
                { "pICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pICMS", "0") },
                { "vICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vICMS", "0") },
                { "modBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/modBCST", "0") },
                { "pMVAST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pMVAST", "0") },
                { "pRedBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pRedBCST", "0") },
                { "vBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vBCST", "0") },
                { "pICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pICMSST", "0") },
                { "vICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vICMSST", "0") },
                { "pCredSN", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pCredSN", "0") },
                { "vCredICMSSN", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vCredICMSSN", "0") },


                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSSN900/vFCPST", "0") }

            };

            return IDictionaryList;
        }
    }
}