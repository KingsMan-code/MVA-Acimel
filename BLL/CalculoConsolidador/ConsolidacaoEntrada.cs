using DAL.Model.Blocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.CalculoConsolidador
{
    public static class ConsolidacaoEntrada
    {
        public static List<BlocoC170> RetornaCalculoMva(List<BlocoC170> ListaNotasDeEntrada)
        {

            ListaNotasDeEntrada.ToList().ForEach(item =>
            {
                //item.MVA = CalculoDoMva(Convert.ToDecimal(item.ICMS_vBCST), Convert.ToDecimal(item.vProd), Convert.ToDecimal(item.IPI_vIPI));
                item.MVA = CalculoDoMva(
                    Convert.ToDecimal(item.VL_BC_ICMS_ST),
                    Convert.ToDecimal(item.VL_ITEM),
                    Convert.ToDecimal(item.VL_IPI));
            });

            return ListaNotasDeEntrada;
        }

        public static string CalculoDoMva(decimal baseStBeneficio, decimal valorProduto, decimal valorIpi)
        {

            decimal Resultado = 0;

            try
            {
                Resultado = baseStBeneficio / (valorProduto + valorIpi) - 1;
            }
            catch (DivideByZeroException)
            {
                Resultado = 0;
            }

            return Resultado.ToString();
        }
    }
}
