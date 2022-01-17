using DAL;
using NOTAS.Metodos.AbstractFactoryFiles;
using NOTAS.Metodos.SpedFile;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVA_UnitTests
{
    [TestFixture]
    public class UploadFilesAnaliseUnitTests
    {

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\Uploads")]
        public void Deve_Retornar_A_Extensao_Do_Arquivo(string input)
        {
            // Definindo o arquivo de entrada
            foreach (var item in UploadFolderRepository.GetAllFilesInDirectory(input))
            {
                IFiles Ifiles = AbstractFiles.RetornaExtensaoArquivo(item.Extension);
                Ifiles.RetornaListaDeNotasFiscaisBaixadas(input, item.FullName, "");
            }
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\Sped\",
            @"C:\Users\Rafael Medeiros\Documents\Arquivos\Uploads")]

        public void Deve_Realizar_O_Download_das_Notas(string input, string uploads)
        {

            List<NOTAS.Models.Notas> Notas = new List<NOTAS.Models.Notas>();

            FileInfo arquivoSped = ArquivoSped
                .RetornaArquivoSpedNoRepositorio($"{input}");
           
            IFiles Ifiles = AbstractFiles
                .RetornaExtensaoArquivo(arquivoSped.Extension);

            Notas = Ifiles
                .RetornaListaDeNotasFiscaisBaixadas(uploads, arquivoSped.FullName, "Saida");


            Assert.IsNotNull(Notas);



        }

    }
}
