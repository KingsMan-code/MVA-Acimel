using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DAL
{
    public static class UploadFolderRepository
    {

        private static readonly object objectLocked = new object();

        public static void ConfiguraDiretorio(string directoryPath)
        {
            try
            {
                Directory.Delete($"{directoryPath}", true);
            }
            catch  {
                
            }

            Directory.CreateDirectory($"{directoryPath}");
        }
       
        public static void DeletaTodoRepositorio(string directoryPath)
        {

            try
            {
                Directory.Delete($"{directoryPath}/Temp", true);
                Directory.Delete($"{directoryPath}/Notas", true);
                Directory.Delete($"{directoryPath}/Uploads", true);
            }
            catch { }
            

            Directory.CreateDirectory($"{directoryPath}/Notas/NotasNaoBaixadas");
            Directory.CreateDirectory($"{directoryPath}/Notas/NotasBaixadas");
            Directory.CreateDirectory($"{directoryPath}/Notas/NotasCanceladas");
            Directory.CreateDirectory($"{directoryPath}/Temp");
            Directory.CreateDirectory($"{directoryPath}/Uploads");
        }

        public static string UploadDeArquivos(string directoryPath, HttpPostedFileBase[] files)
        {
            var totalDeArquivos = 0;
            var fileExtensionTxt = files.ToList().FindAll(x => x.FileName.Contains("txt"));
            var fileExtensionXml = files.ToList().FindAll(x => x.FileName.Contains("xml"));
            var fileExtensionZip = files.ToList().FindAll(x => x.FileName.Contains("zip"));
            var fileExtensioRar = files.ToList().FindAll(x => x.FileName.Contains("rar"));

            if (fileExtensionXml.Count() > 0)
            {

                // Faz o split para poder retornar apenas os números de chaves que foram descartadas
                var notasCanceladas = (from lista in files
                                       where lista.FileName.Contains("-evento-")
                                       select lista.FileName.Split('-').First()).ToList();

                // Adiciona o array de HttpPostedFileBase to List of the HttpPostedFileBase
                List<HttpPostedFileBase> listaDeXmls = new List<HttpPostedFileBase>(files);

                // Deleta da lista de chaves todas as notas que foram canceladas previamente
                foreach (var item in notasCanceladas)
                {
                    HttpPostedFileBase notaCancelada = listaDeXmls.ToList().Find(x => x.FileName.Contains(item));
                    listaDeXmls.Remove(notaCancelada);
                }

                foreach (HttpPostedFileBase file in listaDeXmls)
                {

                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(directoryPath, InputFileName);

                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }

                totalDeArquivos = fileExtensionXml.Count();
            }

            if (fileExtensionTxt.Count() > 0)
            {
                foreach (HttpPostedFileBase file in fileExtensionTxt)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(directoryPath, InputFileName);

                    file.SaveAs(ServerSavePath);
                }

                totalDeArquivos = fileExtensionTxt.Count();
            }

            if(fileExtensionZip.Count() > 0)
            {
                foreach (HttpPostedFileBase file in fileExtensionZip)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(directoryPath, InputFileName);

                    file.SaveAs(ServerSavePath);
                }

                totalDeArquivos = fileExtensionZip.Count();
            }

            if (fileExtensioRar.Count() > 0)
            {
                foreach (HttpPostedFileBase file in fileExtensioRar)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(directoryPath, InputFileName);

                    file.SaveAs(ServerSavePath);
                }

                totalDeArquivos = fileExtensioRar.Count();
            }


            return totalDeArquivos.ToString() + " Arquivo(s) enviado(s) com sucesso.";
        }

        public static FileInfo[] GetAllFilesInDirectory(string directoryPath)
        {
            string[] supportedExtensions = new[] { ".txt",".xml",".xls,",".xlsx" };

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            return directoryInfo.GetFiles("*.*", SearchOption.AllDirectories)
                .Where(f => supportedExtensions.Contains(f.Extension.ToLower())).ToArray();
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
    }
}
