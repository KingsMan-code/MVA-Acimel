using NOTAS.Metodos.AbstractFactoryFiles;
using NUnit.Framework;
using System.IO;

namespace NotasUnitTests
{

    [TestFixture]
    public class ExtensaoUnitTests
    {
        [TestCase("barnabe.txt")]
        public void Deve_Retornar_Extensao_Txt(string input)
        {

            string inputExtensionFile = Path.GetExtension(input);

            IFiles iArquivo = AbstractFiles.RetornaExtensaoArquivo(inputExtensionFile);

            Assert.AreEqual("ArquivoTexto", iArquivo.GetType().Name);

        }

        [TestCase("barnabe.xls")]
        public void Deve_Retornar_Extensao_Xls(string input)
        {

            string inputExtensionFile = Path.GetExtension(input);

            IFiles iArquivo = AbstractFiles.RetornaExtensaoArquivo(inputExtensionFile);

            Assert.AreEqual("ArquivoXls", iArquivo.GetType().Name);

        }

        [TestCase("barnabe.xlsx")]
        public void Deve_Retornar_Extensao_Xlsx(string input)
        {

            string inputExtensionFile = Path.GetExtension(input);

            IFiles iArquivo = AbstractFiles.RetornaExtensaoArquivo(inputExtensionFile);

            Assert.AreEqual("ArquivoXlsx", iArquivo.GetType().Name);

        }
    }
}
