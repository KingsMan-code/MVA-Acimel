using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NOTAS.Metodos.JSON
{
    public static class Json
    {
        public static string Deserializar(string xml)
        {
           return Newtonsoft.Json.JsonConvert.DeserializeXmlNode(xml).InnerText;
        }
    }
}