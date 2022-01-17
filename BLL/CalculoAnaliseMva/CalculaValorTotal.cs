using DAL.Model;
using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Calculos
{
    public static class CalculaValorTotal
    {

        private static decimal ValorDoProduto { get; set; } = 0;
        private static decimal Frete { get; set; } = 0;
        private static decimal OutrasDespesas { get; set; } = 0;
        private static decimal Desconto { get; set; } = 0;
        private static decimal ValorDoIpi { get; set; } = 0;
        private static decimal ValorIcmsST { get; set; } = 0;
        private static decimal Resultado { get; set; } 


        public static string Calculo(NotaAnalise nota)
        {


            // Try parse valor do produto value to decimal return true or false  
            if (decimal.TryParse(nota.vProd, out decimal valorDoProdutoParsedValue))
            {
                ValorDoProduto = valorDoProdutoParsedValue;
            }

            // Try parse frete value to decimal return true or false  
            if (decimal.TryParse(nota.Frete, out decimal freteParsedValue))
            {
                Frete = freteParsedValue;
            }

            // Try parse outras despesas value to decimal return true or false  
            if (decimal.TryParse(nota.Descontos, out decimal outrasDespesasParsedValue))
            {
                OutrasDespesas = outrasDespesasParsedValue;
            }

            // Try parse ValorDoIpi value to decimal return true or false  
            if (decimal.TryParse(nota.IPI_vIPI, out decimal ipiParsedValue))
            {
                ValorDoIpi = ipiParsedValue;
            }

            // Try parse ValorDoIpi value to decimal return true or false  
            if (decimal.TryParse(nota.ICMS_vICMSST, out decimal vicmsstParsedValue))
            {
                ValorIcmsST = vicmsstParsedValue;
            }

            // VLR DOS PROTUDOS(Antigo Vlr Total) + FRETE + DESPESAS ACESSÓRIAS – DESCONTO + IPI + VLR DO ICMS SUBST
            Resultado = ((ValorDoProduto + Frete + OutrasDespesas) - Desconto + (ValorDoIpi + ValorIcmsST));

            return Resultado.ToString("C").Replace("R$", "");
            
        }

        public static string Calculo(NotaConsolidada nota)
        {


            // Try parse valor do produto value to decimal return true or false  
            if (decimal.TryParse(nota.vProd, out decimal valorDoProdutoParsedValue))
            {
                ValorDoProduto = valorDoProdutoParsedValue;
            }

            // Try parse frete value to decimal return true or false  
            if (decimal.TryParse(nota.Frete, out decimal freteParsedValue))
            {
                Frete = freteParsedValue;
            }

            // Try parse outras despesas value to decimal return true or false  
            if (decimal.TryParse(nota.Descontos, out decimal outrasDespesasParsedValue))
            {
                OutrasDespesas = outrasDespesasParsedValue;
            }

            // Try parse ValorDoIpi value to decimal return true or false  
            if (decimal.TryParse(nota.IPI_vIPI, out decimal ipiParsedValue))
            {
                ValorDoIpi = ipiParsedValue;
            }

            // Try parse ValorDoIpi value to decimal return true or false  
            if (decimal.TryParse(nota.ICMS_vICMSST, out decimal vicmsstParsedValue))
            {
                ValorIcmsST = vicmsstParsedValue;
            }

            // VLR DOS PROTUDOS(Antigo Vlr Total) + FRETE + DESPESAS ACESSÓRIAS – DESCONTO + IPI + VLR DO ICMS SUBST
            Resultado = ((ValorDoProduto + Frete + OutrasDespesas) - Desconto + (ValorDoIpi + ValorIcmsST));

            return Resultado.ToString("C").Replace("R$", "");

        }

    }
}
