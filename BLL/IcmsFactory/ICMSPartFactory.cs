using DAL.Layout;
using System.Collections.Generic;
using System.Xml;

namespace DAL
{
    internal class ICMSPartFactory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> IDictionaryList { get; set; }
      
        IDictionary<string, string> IModalidadeDeIcms.RetornaModalidadeDeIcms(XmlNode node)
        {
            IDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "orig", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/orig", "0") },
                { "CST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/CST", "0") },
                { "modBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/modBC", "0") },
                { "vBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vBC", "0") },
                { "pRedBC", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pRedBC", "0") },
                { "pICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pICMS", "0") },
                { "vICMS", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vICMS", "0") },
                { "modBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/modBCST", "0") },
                { "pMVAST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pMVAST", "0") },
                { "pRedBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pRedBCST", "0") },
                { "vBCST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vBCST", "0") },
                { "pICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pICMSST", "0") },
                { "vICMSST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vICMSST", "0") },
                { "pBCOp", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pBCOp", "0") },
                { "UFST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/UFST", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMSPart/vFCPST", "0") }

            };

            return IDictionaryList;
        }
    }
}