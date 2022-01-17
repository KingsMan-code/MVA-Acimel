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
    public class RelatorioNotasFiscaisUnitTest
    {

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\Notas\NotasBaixadas")]
        public void Deve_Retornar_Apenas_As_Notas_Que_Foram_Baixadas(string input)
        {
            int str = Diretorio.DeveRetornarTodasAsXmlsNoDiretorio(input);

            Assert.AreEqual(46, str);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\Notas\NotasCanceladas")]
        public void Deve_Retornar_Apenas_As_Notas_Que_Foram_Canceladas(string input)
        {
            int str = Diretorio.DeveRetornarTodasAsXmlsNoDiretorio(input);

            Assert.AreEqual(4, str);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\Notas\NotasNaoBaixadas")]
        public void Deve_Retornar_Apenas_As_Notas_Que_Nao_Foram_Baixadas(string input)
        {
            int str = Diretorio.DeveQuantidadeDeNotasNaoBaixadas(input);
            Assert.AreEqual(12, str);
        }

    }
}
