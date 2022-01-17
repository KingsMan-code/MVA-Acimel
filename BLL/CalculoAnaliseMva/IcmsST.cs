using DAL.Model;
using System;

namespace DAL
{
    public static class IcmsST
    {

        private static decimal BaseDoIcmsSt { get; set; } = 0;
        private static decimal ValorIcms { get; set; } = 0;
        private static decimal AliquotaInterna { get; set; } = 0;
        private static decimal Resultado { get; set; } = 0;


        public static string Calculo(string baseIcmsStBeneficio, decimal aliquotaInterna, string valorIcms)
        {

            AliquotaInterna = aliquotaInterna;
     
            if (decimal.TryParse(valorIcms, out decimal valorIcmsParsed))
            {
                ValorIcms = valorIcmsParsed;
            }
            if (decimal.TryParse(baseIcmsStBeneficio, out decimal baseIcmsParsed))
            {
                BaseDoIcmsSt = baseIcmsParsed;
            }

            try
            {
                Resultado = ((BaseDoIcmsSt * AliquotaInterna / 100) - ValorIcms);
            }
            catch (DivideByZeroException)
            {
                Resultado = 0;
            }

            return Resultado.ToString("C").Replace("R$", "") ;
        }

    }
}
