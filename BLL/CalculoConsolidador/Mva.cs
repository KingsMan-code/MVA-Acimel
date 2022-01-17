using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CalculoConsolidador
{
    public class Mva
    {
        public static string Resultado(IList<NotaConsolidada> notasConsolidadasEntrada, IList<NotaConsolidada> notasConsolidadasSaida)
        {
            //// Compara pra ver qual é o maior valor
            //_total = (_calculoMva > _calculoMarkup) ?
            //$"O valor total da entrada: { _calculoMva.ToString("C")} é maior do que a saída: {_calculoMarkup.ToString("C")}" :
            //$"O valor total da saída: {_calculoMarkup.ToString("C")} é maior do que a entrada: {_calculoMva.ToString("C")}";


            //_total = $"Erro ao tentar dividir por zero: Entrada {entradaValorUnidadeComercial.ToString("C").Replace("R$", "")} e Saída {saidaValorUnidadeComercial.ToString("C").Replace("R$", "")}";

            return "";
        }

    }
}
