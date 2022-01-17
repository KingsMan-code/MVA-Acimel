using NOTAS.Metodos.AbstractFactoryFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVA.Metodos.Upload
{
    public class UploadFolderRepositoryBaixarNotas
    {
        private static readonly object objectLocked = new object();

        /// <summary>
        /// Verifica se existem arquivos no diretório. Se existirem, eles serão deletados antes de baixar novos
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void DeletaSubdiretorios(string directoryPath)
        {

            string[] Diretorios = Directory
                .GetDirectories(directoryPath)
                .ToList()
                .Where(x => !x.Contains("NotasNaoBaixadas")
                && !x.Contains("NotasCanceladas")).ToArray();

            foreach (string item in Diretorios)
            {
                try
                {
                    Directory.Delete(item, true);
                }
                catch
                {
                }
            }
        }

        public static void DeletaTodosOsArquivosDentroDoDiretorio(string directoryPath)
        {
            DirectoryInfo info = new DirectoryInfo(directoryPath);
            DirectoryInfo[] dir = info.GetDirectories("", SearchOption.AllDirectories);
            FileInfo[] files = info.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    File.Delete(file.FullName);
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Realiza o upload dos arquivos para o servidor, determinando automaticamente o tipo de arquivo
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public static void UploadDeArquivos(string directoryPath, FileInfo[] pathOfFiles)
        {

            foreach (FileInfo file in pathOfFiles)
            {
                if (file != null)
                {
                    if (file.Extension.Contains("xml")) return;

                    // Get extension from input file
                    var inputExtensionFile = Path.GetExtension(file.FullName);
                    string ServerSavePath = string.Empty;

                    // Retorna o tipo de arquivo
                    IFiles iFiles = AbstractFiles.RetornaExtensaoArquivo(inputExtensionFile);

                    // Trata o arquivo de acordo com a extensão passada 
                    iFiles.RetornaListaDeNotasFiscaisBaixadas(directoryPath, file.FullName, "");
                }
            }
        }

        public static FileInfo[] GetAllFilesInDirectory(string directoryPath)
        {
            DirectoryInfo file = new DirectoryInfo(directoryPath);
            return file.GetFiles("*.xml", SearchOption.AllDirectories);
        }
    }
}