using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CalculoAnaliseMva
{
    public class CalculaFcp
    {

        /// <summary>
        /// Realiza a soma entre o valor do ICMS e o valor do fundo de combate à pobreza
        /// </summary>
        /// <param name="valorIcms"></param>
        /// <param name="ValorFcp"></param>
        /// <returns></returns>
        public static string CalculaValorICMSeValorFundoCombatePobreza(string valorIcms, string ValorFcp)
        {
            decimal _valorIcms = Convert.ToDecimal(valorIcms);
            decimal _valorFcp = Convert.ToDecimal(ValorFcp);
            return (_valorIcms + _valorFcp).ToString("C").Replace("R$", "");
        }


        /// <summary>
        /// Realiza a soma entre o valor do ICMSST e o valor do Funco de combate à pobreza por Substituição Tributária
        /// </summary>
        /// <param name="valorIcmsSt"></param>
        /// <param name="ValorFcpSubTrib"></param>
        /// <returns></returns>
        public static string CalculaValorICMSSTeFundoCombatePobrezaSubstituicaoTributaria(string valorIcmsSt, string ValorFcpSubTrib)
        {
            decimal _valorIcmsSt = Convert.ToDecimal(valorIcmsSt);
            decimal _valorFcpSubTrib = Convert.ToDecimal(ValorFcpSubTrib);
            return (_valorIcmsSt + _valorFcpSubTrib).ToString("C").Replace("R$", "");
        }

        /// <summary>
        ///  Realiza a soma entre à Aliquota e o Percentual do fundoi de combate à pobreza
        /// </summary>
        /// <param name="aliquota"></param>
        /// <param name="pfCPST"></param>
        /// <returns></returns>
        public static string CalculaAliquotaIcmsePercentualFundoCombatePobreza(string aliquota, string pfCPST)
        {

            decimal _aliquota = Convert.ToDecimal(aliquota);
            decimal _pfCPST = Convert.ToDecimal(pfCPST);
            return  Math.Round(_aliquota + _pfCPST).ToString();

        }

        /// <summary>
        ///  Realiza a soma do imposto do ICMSST e o Percentual do Fundo de Combate à Pobreza por Substituição Tributária
        /// </summary>
        /// <param name="aliquotaIcmsSt"></param>
        /// <param name="pfCPST"></param>
        /// <returns></returns>
        public static string CalculaAliquotaImpostoIcmsStePercentualFcpSubTributaria(string aliquotaIcmsSt, string pfCPST)
        {
            decimal _aliquotaIcmsSt = Convert.ToDecimal(aliquotaIcmsSt);
            decimal _pfCPST = Convert.ToDecimal(pfCPST);
            return (_aliquotaIcmsSt + _pfCPST).ToString("C").Replace("R$", "");
        }
    }
}
