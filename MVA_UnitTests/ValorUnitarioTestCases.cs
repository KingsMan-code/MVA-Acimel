using DAL.Layout;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{
    [TestFixture]
    public class ValorUnitario_UnitTests
    {
        
        [TestCase("", "0")]
        [TestCase("1.2000000000", "1,2000")]
        [TestCase("7.9", "7,9000")]
        [TestCase("7.38", "7,3800")]
        [TestCase("9.90000000", "9,9000")]
        [TestCase("38.790000", "38,7900")]
        [TestCase("1.2000000000", "1,2000")]
        [TestCase("1590.0000000000", "1.590,0000")]
        [TestCase("300.5500000", "300,5500")]
        [TestCase("109.2300000000", "109,2300")]
        [TestCase("10.000", "10,0000")]
        [TestCase("1000.0000", "1.000,0000")]
        [TestCase("1.2000000000", "1,2000")]

        public void Deve_Retornar_O_Valor_Unitario_Com_Quatro_Digitos_A_Direita(string values, string valorEsperado)
        {
            var str = Validacao.RetornaValorUnitarioFormatado(values);

            Assert.That(str, Is.EqualTo(valorEsperado));
        }

        
    }
}
