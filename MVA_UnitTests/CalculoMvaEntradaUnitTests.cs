using BLL.CalculoConsolidador;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{
    [TestFixture]
    public class CalculoMvaEntradaUnitTests
    {


        [TestCase(50400.00, 24000.00, 4000.00, "0,8")]
        public void Deve_Retornar_Resultado_Calculo_MVA(decimal baseStBeneficio, decimal valorProduto, decimal valorIpi, string valorEsperado)
        {
            string resultado = ConsolidacaoEntrada.CalculoDoMva(baseStBeneficio, valorProduto, valorIpi);

            Assert.That(resultado, Is.EqualTo(valorEsperado));
        }



    }
}
