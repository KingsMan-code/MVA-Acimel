using DAL.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.IcmsFactory
{
    public class Icms60Factory : IModalidadeDeIcms
    {

        internal IDictionary<string, string> iDictionaryList { get; set; }
      
        IDictionary<string, string> IModalidadeDeIcms.RetornaModalidadeDeIcms(XmlNode node)
        {
            iDictionaryList = new Dictionary<string, string>
            {
                { "CodigoProduto", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//prod/cProd", "0") },
                { "Orig", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/orig", "0") },
                { "CST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/CST", "0")},
                { "vBCSTRet", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/vBCSTRet", "0") },
                { "vICMSSTRet", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/vICMSSTRet", "0") },

                { "vBCFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/vBCFCP", "0") },
                { "pFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/pFCP", "0") },
                { "vFCP", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/vFCP", "0") },
                { "vBCFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/vBCFCPST", "0") },
                { "pFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/pFCPST", "0") },
                { "vFCPST", Validacao.CheckIfNodeIsNullOrEmpty(node, ".//imposto/ICMS/ICMS60/vFCPST", "0") }

            };

            return iDictionaryList;
        }
    }
}
