using BLL.CalculoConsolidador;
using DAL.Model;
using DAL.Model.LayoutXml;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{
    [TestFixture]
    public class MarkupUnitTests
    {

        [Test]
        public void Deve_Retornar_O_Calculo_Do_MVA()
        {

            List<NotaConsolidada> XmlNotasEntrada = new List<NotaConsolidada>()
            {
                new NotaConsolidada
                {
                     TipoNotaFiscal = "entrada",
                    NCM = "0001",
                    vUnCom = "300,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "entrada",
                    NCM = "0001",
                    vUnCom = "500,00",
                },
           new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0002",
                    vUnCom = "700,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0002",
                    vUnCom = "300,00",
                },
               new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0003",
                    vUnCom = "700,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0003",
                    vUnCom = "300,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "entrada",
                    NCM = "0004",
                    vUnCom = "300,00",
                }
            };
            List<NotaConsolidada> XmlNotasSaida = new List<NotaConsolidada>()
            {
                 new NotaConsolidada
                {
                     TipoNotaFiscal = "entrada",
                    NCM = "0001",
                    vUnCom = "300,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "entrada",
                    NCM = "0001",
                    vUnCom = "500,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0002",
                    vUnCom = "700,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0002",
                    vUnCom = "300,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0003",
                    vUnCom = "700,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0003",
                    vUnCom = "300,00",
                }
            };

           // IList<ResultadoFinalMva> ListaFinal = Markup.UnidadeComercial(XmlNotasEntrada, XmlNotasSaida);
            //Assert.IsNotNull(ListaFinal);
        }

        [Test]
        public void Deve_Retornar_O_Calculo_Do_MVA_Para_Os_Ncms_Sem_Grupos()
        {
            List<NotaConsolidada> XmlNotasEntrada = new List<NotaConsolidada>()
            {
                 new NotaConsolidada
                {
                     TipoNotaFiscal = "entrada",
                    NCM = "0001",
                    vUnCom = "300,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "entrada",
                    NCM = "0002",
                    vUnCom = "500,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0003",
                    vUnCom = "700,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0004",
                    vUnCom = "300,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0005",
                    vUnCom = "700,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0006",
                    vUnCom = "300,00",
                }
            };
            List<NotaConsolidada> XmlNotasSaida = new List<NotaConsolidada>()
            {
                 new NotaConsolidada
                {
                     TipoNotaFiscal = "entrada",
                    NCM = "0010",
                    vUnCom = "300,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "entrada",
                    NCM = "0011",
                    vUnCom = "500,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0012",
                    vUnCom = "700,00",
                },
                new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0013",
                    vUnCom = "300,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0014",
                    vUnCom = "700,00",
                },
                 new NotaConsolidada
                {
                    TipoNotaFiscal = "saida",
                    NCM = "0015",
                    vUnCom = "300,00",
                }
            };

          //  IList<ResultadoFinalMva> ListaFinal = Markup.UnidadeComercial(XmlNotasEntrada, XmlNotasSaida);
       //     Assert.IsNotNull(ListaFinal);
        }


    }
}
