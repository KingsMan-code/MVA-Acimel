using BLL.CalculoConsolidador;
using DAL;
using DAL.Layout;
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
    public class QuantValor_UnitTests
    {

        [TestCase("", "0,00")]
        [TestCase("7.52", "7,52")]

        public void Deve_Retornar_O_Valor_Unitario_Com_Quatro_Digitos_A_Direita(string values, string valorEsperado)
        {
            var str = Validacao.RetornaValorDecimal(values);

            Assert.That(str, Is.EqualTo(valorEsperado));
        }

        [Test]
        public void Deve_Retornar_O_Resultado_Do_Calculo_Das_Notas_Entrada_E_Saida()
        {

            List<NotaConsolidada> notasEntrada = new List<NotaConsolidada>();
            List<NotaConsolidada> notasSaida = new List<NotaConsolidada>();

            notasEntrada.Add(new NotaConsolidada
            {
                Mva = "5.000,22",
                vUnCom = "400.00"
            });

            notasSaida.Add(new NotaConsolidada
            {
                vUnCom = "800.00"
            });


            string valor = Mva.Resultado(notasEntrada, notasSaida);

        }


        [Test]
        public void Deve_Mudar_O_Valor_Quando_For_Negativo()
        {

            List<NotaConsolidada> notasEntrada = new List<NotaConsolidada>();
            List<NotaConsolidada> notasSaida = new List<NotaConsolidada>();

            notasEntrada.Add(new NotaConsolidada
            {
                Mva = "-5.000,22",
                vUnCom = "400.00"
            });

            notasSaida.Add(new NotaConsolidada
            {
                vUnCom = "800.00"
            });


            string valor = Mva.Resultado(notasEntrada, notasSaida);

        }





    }
}
