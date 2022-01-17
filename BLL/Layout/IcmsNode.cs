using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Layout
{
    public static class IcmsNode
    {

        public static IDictionary<string, string> RetornaIcmsNode(XmlNode produto)
        {

            bool icmsNodeValue = false;
            IDictionary<string, string> dictionaryIcmsLayout = new Dictionary<string, string>();

            foreach (XmlNode item in produto.SelectNodes(".//imposto/ICMS"))
            {

                XmlNode firstNode = item.FirstChild;

                if (firstNode.Name.Contains("ICMS"))
                {
                    icmsNodeValue = (!string.IsNullOrWhiteSpace(produto.SelectSingleNode(".//imposto/ICMS").ChildNodes[0].Name) ? true : false);

                    if (icmsNodeValue)
                    {
                        var icmsNode = produto
                            .SelectSingleNode(".//imposto/ICMS")
                            .ChildNodes[0]
                            .Name;

                        dictionaryIcmsLayout = NotaFiscalProduto.RetornaDicionarioComIcms(icmsNode, produto);
                    }
                }
                else
                {
                    dictionaryIcmsLayout.Add("-", "-");
                }
            }

            return dictionaryIcmsLayout;

        }

    }
}
