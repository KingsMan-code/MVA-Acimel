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
    public class VerificaDiretorioArquivosDeEntradaUnitTests
    {

        [TestCase(false)]
        public void DeveConfigurarPastaDeArquivos(bool result)
        {
            var usuario = "Leticia";

            // Verifica se existem arquivs no repositório do servidor
            UploadFolderRepository.ConfiguraDiretorio($"C:/Projetos/Projetos Especiais/MVA/MVA/MVA/Areas/Restrito/UploadedFiles/{usuario}/Consolidar/Entrada");

            bool ast = System.IO.File.Exists($"C:/Projetos/Projetos Especiais/MVA/MVA/MVA/Areas/Restrito/UploadedFiles/{usuario}/Consolidar/Entrada");

            Assert.AreEqual(ast, result);
        }



    }
}
