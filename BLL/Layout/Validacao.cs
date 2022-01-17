using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace DAL.Layout
{
    public class Validacao
    {
        public static string CheckIfNodeIsNullOrEmpty(XmlNode node, string selectNode, string tipoDeRetorno)
        {
            return (node.SelectSingleNode(selectNode) == null) ? tipoDeRetorno : node.SelectSingleNode(selectNode).InnerText;
        }
        public static string CheckIfDictionaryValueExists(dynamic obj, string name)
        {
            try
            {
                var value = obj[name];
                return value;
            }
            catch (KeyNotFoundException)
            {
                return "0,00";
            }
        }
        public static string RetornaValorUnitarioFormatado(string valor)
        {

            var hasOnlyZero = (string.IsNullOrEmpty(valor.Trim('0').Replace(".", "")) ? true : false);

            if (hasOnlyZero) { return "0"; }


            string output = string.Empty;

            var hasParse = decimal.TryParse(valor.Replace(".", ","), out decimal decimalValueParced);

            if(hasParse)
            {
                output = decimalValueParced
                    .ToString("C4")
                    .Replace("R$", "");
            }

            return output;

        }
        public static string RetornaValorDecimal(string valor)
        {

            var hasOnlyZero = (string.IsNullOrEmpty(valor.Trim('0').Replace(".", "")) ? true : false);

            if (hasOnlyZero) { return "0,00"; }


            string output = string.Empty;

            var hasParse = decimal.TryParse(valor.Replace(".", ","), out decimal decimalValueParced);

            if (hasParse)
            {
                output = decimalValueParced
                    .ToString("C")
                    .Replace("R$", "");
            }

            return output;

        }
    }
}
