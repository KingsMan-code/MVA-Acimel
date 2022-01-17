using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NOTAS.Metodos.Data
{
    public static class ConverterData
    {
        public static string Formatar(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return DateTime.Now.ToString("MM/dd/yyyy");
            }

            DateTime dt = Convert.ToDateTime(input);
            return dt.ToString("MM/dd/yyyy");
        }
    }
}