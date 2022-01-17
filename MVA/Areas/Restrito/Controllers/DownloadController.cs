using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVA.Areas.Restrito.Controllers
{
    [Authorize]
    public class DownloadController : Controller
    {
        private static string Usuario = string.Empty;


        public ActionResult Index()
        {

            // Pega a sessão atual do usuário
            Usuario = Session["nomeUsuarioLogado"].ToString();

            // Coleta o path de todas as xmls na pasta notas
            string[] notas = Directory
                .GetFiles(
                Server.MapPath($"~/UploadedFiles/{Usuario}/Notas/"),
                "*.xml",
                SearchOption.AllDirectories)
                .Where(x => !x.Contains("NotasCanceladas") && !x.Contains("NotasNaoBaixadas")).ToArray();

            // Coleta a quantidade de informações de notas baixadas
            if (notas.Length > 0)
            {
                ViewBag.NotasBaixadas = notas.Count();
            }
            else
            {
                ViewBag.NotasBaixadas = 0;
            }

            // Coleta a quantidade de informações de notas canceladas
            string[] notasCanceladas = Directory
            .GetFiles(
            Server.MapPath($"~/UploadedFiles/{Usuario}/Notas/NotasCanceladas"),
            "*.xml",
            SearchOption.AllDirectories);

            // Coleta a quantidade de notas canceladas na pasta
            if (notasCanceladas.Length > 0)
            {
                ViewBag.Canceladas = notasCanceladas.Count();
            }
            else
            {
                ViewBag.Canceladas = 0;
            }

            // Coleta a quantidade de notas que não foram baixadas
            string[] log = Directory.GetFiles(Server.MapPath($"~/UploadedFiles/{Usuario}/Notas/NotasNaoBaixadas"), "*.txt");
            if (log.Length > 0)
            {
                ViewBag.NotasNaoEncontradas = System.IO.File.ReadAllLines(log[0]).Count();
            }
            else
            {
                ViewBag.NotasNaoEncontradas = 0;
            }

            return View();
        }

        [HttpGet]
        public FilePathResult Download()
        {
            // Define o diretório das notas
            string diretorioNotas = Server.MapPath($"~/UploadedFiles/{Usuario}/Notas");

            // Define o diretório temporário 
            string diretorioTemp = Server.MapPath($"~/UploadedFiles/{Usuario}/Temp");

            // Cria o nome para o arquivo
            string notasZip = $"{diretorioTemp}//NotasBaixadas_{DateTime.Now.ToString("dd-MM-yyyy")}.zip";

            // 
            string notasFileName = $"NotasBaixadas_{DateTime.Now.ToString("dd-MM-yyyy")}.zip";

            // Zipa as pastas 
            ZipFile.CreateFromDirectory(diretorioNotas, notasZip, CompressionLevel.Optimal, true);

            return File(notasZip, "application/zip", notasFileName);
        }
    }
}