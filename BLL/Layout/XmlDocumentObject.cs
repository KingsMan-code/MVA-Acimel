using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Layout
{
    public class XmlDocumentObject
    {
        private static readonly string FILTER = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";

        public static XmlDocument RetornaXmlDocument(string nota)
        {

            XmlDocument doc = new XmlDocument();

            doc.Load(nota);

            var response = Regex.Replace(doc.InnerXml, FILTER, "");

            doc.LoadXml(response);

            return doc;

        }
    }
}
