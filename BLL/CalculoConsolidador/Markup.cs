using DAL.Model;
using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CalculoConsolidador
{

    public class Markup
    {

        public static decimal TotalDaEntrada { get; set; }
        public static decimal TotalDaSaida { get; set; }
        public static string Valor { get; set; }
        public static string Ncm { get; set; }
        public static string Quantidade { get; set; }

        public static void UnidadeComercial(List<NotaConsolidada> xmlSaida)
        {
        }


        private static List<ResultadoFinalMva> RetornaCalculoDoMva(List<NotaConsolidada> NotasConsolidadas, IEnumerable<string> ncmsFiltrados)
        {

            List<ResultadoFinalMva> listaFinal = new List<ResultadoFinalMva>();

            foreach (var ncm in ncmsFiltrados)
            {

                TotalDaEntrada = 0;
                TotalDaSaida = 0;
                Quantidade = string.Empty;
                Valor = string.Empty;
                Ncm = string.Empty;

                // Retorna todos os NCMS/Produtos que estiverem repetidos 
                var grupoDeNcm = NotasConsolidadas.FindAll(x => x.NCM == ncm);
                Quantidade = $" Quantidade: {grupoDeNcm.Count().ToString()}";

                if (grupoDeNcm != null)
                {

                    foreach (var _item in grupoDeNcm)
                    {
                        // Verifica pelo tipo de nota se e entrada ou saída e faz o cálculo
                        if (_item.TipoNotaFiscal.Equals("entrada"))
                        {
                            TotalDaEntrada += Convert.ToDecimal(_item.vUnCom);
                        }
                        else if (_item.TipoNotaFiscal.Equals("saida"))
                        {
                            TotalDaSaida = TotalDaSaida + Convert.ToDecimal(_item.vUnCom);
                        }

                        //
                        // Verifica se entrada é maior do que saída
                        //
                        Valor = ((TotalDaEntrada > TotalDaSaida) ?
                            $"O valor de entrada: {TotalDaEntrada.ToString("C").Replace("R$", "")} é maior do que a saída: {TotalDaSaida.ToString("C").Replace("R$", "")}" :
                            $"O valor de saída: {TotalDaSaida.ToString("C").Replace("R$", "")} é maior do que a entrada: {TotalDaEntrada.ToString("C").Replace("R$", "")}");

                        // Ncm do grupo
                        Ncm = $"NCM: {_item.NCM}" + Quantidade;

                    };

                }

               
                // Cria a lista com o resultado retornando
                listaFinal.Add(new ResultadoFinalMva
                {
                    Ncm = Ncm,
                    Total = Valor
                });

            }

            return listaFinal;
        }

    }
}
