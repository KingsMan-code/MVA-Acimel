using BLL.CalculoConsolidador;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{

    [TestFixture]
    public class ConsolidarNotasUnitTests
    {

        //[TestCase("07067777000112")]
        //public void Deve_Retornar_Valor_Total_Das_Notas_Consolidadas(string cnpj)
        //{

        //    string[] notasXmls = System.IO.Directory.GetFiles(@"C:\Users\Rafael Medeiros\Desktop\NFEs_Recebidas_01-07-2018-31-07-2018_\TESTE", "*.xml");
        //    List<string> Notas = new List<string>(notasXmls);

        //    NotaFiscalProduto.ConsolidarNotas(Notas, cnpj);
      
        //}

        //[TestCase("3.328.71", "0.00", "6.488.92", "94,94")]
        //[TestCase("3.328.71", "594.94", "6.488.92", "94,59")]
        //public void Deve_Calcular_MVA_Entrada(decimal valorDoProduto, decimal valorIpi, decimal valorBaseCalculoIcmsSt, decimal valorEsperado)
        //{
        //    string valor = ConsolidacaoEntrada.CalculoDoMva(valorDoProduto, valorIpi, valorBaseCalculoIcmsSt);

        //   Assert.That(valor, Is.EqualTo(valorEsperado));
        //}

    }
}
