using DAL.Model;
using DAL.Model.LayoutXml;
using System;

namespace DAL
{
    public static class BaseIcmsST
    {


        private static decimal ValorDoProduto { get; set; } = 0;
        private static decimal ValorDoIpi { get; set; } = 0;
        private static decimal Frete { get; set; } = 0;
        private static decimal Seguro { get; set; } = 0;
        private static decimal OutrasDespesas { get; set; } = 0;
        private static decimal Descontos { get; set; } = 0;
        private static decimal AliquotaInterna { get; set; } = 0;
        private static decimal Resultado { get; set; } = 0;


        public static string Calculo(NotaAnalise nota, decimal aliquotaInterna)
        {

            AliquotaInterna = aliquotaInterna;

            // Try parse valor do produto to decimal return true or false   
            if (decimal.TryParse(nota.vProd, out decimal notaParsedValue))
            {
                ValorDoProduto = notaParsedValue;
            }

            // Try parse ipi value to decimal return true or false  
            if (decimal.TryParse(nota.IPI_vIPI, out decimal ipiParsedValue))
            {
                ValorDoIpi = ipiParsedValue;
            }

            // Try parse Frete do produto to decimal return true or false   
            if (decimal.TryParse(nota.Frete, out decimal freteParsedValue))
            {
                Frete = freteParsedValue;
            }

            // Try parse Seguro value to decimal return true or false  
            if (decimal.TryParse(nota.Seguro, out decimal seguroParsedValue))
            {
                Seguro = seguroParsedValue;
            }

            // Try parse outras despesas to decimal return true or false   
            if (decimal.TryParse(nota.OutrasDespesas, out decimal outrasDespesasParsedValue))
            {
                OutrasDespesas = outrasDespesasParsedValue;
            }

            // Try parse ipi value to decimal return true or false  
            if (decimal.TryParse(nota.Descontos, out decimal descontosParsedValue))
            {
                Descontos = descontosParsedValue;
            }


            try
            {
                Resultado = (ValorDoProduto + ValorDoIpi + Frete + Seguro + OutrasDespesas - Descontos) * (1 + (AliquotaInterna / 100));
            }
            catch (DivideByZeroException)
            {
                Resultado = 0;
            }

            return Resultado.ToString("C").Replace("R$", "");

        }

        public static string Calculo(NotaConsolidada nota, decimal aliquotaInterna)
        {

            AliquotaInterna = aliquotaInterna;

            // Try parse valor do produto to decimal return true or false   
            if (decimal.TryParse(nota.vProd, out decimal notaParsedValue))
            {
                ValorDoProduto = notaParsedValue;
            }

            // Try parse ipi value to decimal return true or false  
            if (decimal.TryParse(nota.IPI_vIPI, out decimal ipiParsedValue))
            {
                ValorDoIpi = ipiParsedValue;
            }

            // Try parse Frete do produto to decimal return true or false   
            if (decimal.TryParse(nota.Frete, out decimal freteParsedValue))
            {
                Frete = freteParsedValue;
            }

            // Try parse Seguro value to decimal return true or false  
            if (decimal.TryParse(nota.Seguro, out decimal seguroParsedValue))
            {
                Seguro = seguroParsedValue;
            }

            // Try parse outras despesas to decimal return true or false   
            if (decimal.TryParse(nota.OutrasDespesas, out decimal outrasDespesasParsedValue))
            {
                OutrasDespesas = outrasDespesasParsedValue;
            }

            // Try parse ipi value to decimal return true or false  
            if (decimal.TryParse(nota.Descontos, out decimal descontosParsedValue))
            {
                Descontos = descontosParsedValue;
            }


            try
            {
                Resultado = (ValorDoProduto + ValorDoIpi + Frete + Seguro + OutrasDespesas - Descontos) * (1 + (AliquotaInterna / 100));
            }
            catch (DivideByZeroException)
            {
                Resultado = 0;
            }

            return Resultado.ToString("C").Replace("R$", "");

        }
    }
}
