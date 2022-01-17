using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CalculoConsolidador
{
    public static class ConsolidarSaida
    {

        private static decimal ValorUnitarioEntrada { get; set; } = 0;
        private static decimal ValorUnitarioSaida { get; set; } = 0;
        private static decimal Resultado { get; set; } = 0;


        public static string Calculo(string valorUnitarioEntrada, string valorUnitarioSaida)
        {


            if (decimal.TryParse(valorUnitarioEntrada, out decimal valorUnitarioEntradaParsed))
            {
                ValorUnitarioEntrada = valorUnitarioEntradaParsed;
            }

            if (decimal.TryParse(valorUnitarioSaida, out decimal valorUnitarioSaidaParsed))
            {
                ValorUnitarioSaida = valorUnitarioSaidaParsed;
            }

            try
            {
                Resultado = ((ValorUnitarioSaida / ValorUnitarioEntrada) * 100);

            }
            catch (DivideByZeroException)
            {
                Resultado = 0;
            }

            return Resultado.ToString("C").Replace("R$", "");
        }


    }
}
