using BLL.Layout;
using DAL;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Model.Blocos;
using NOTAS.Metodos.SpedFile;
using NOTAS.Metodos.AbstractFactoryFiles;
using DAL.Model;

namespace MVA.Areas.Restrito.Controllers
{
    [Authorize]
    public class ConsolidarController : Controller
    {

        public static string Usuario = string.Empty;
        public static string DiretorioConsolidar = string.Empty;
        public static string Cnpj = string.Empty;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadArquivosRepositorioConsolidar(HttpPostedFileBase[] files)
        {

            if (ModelState.IsValid)
            {

                UploadFolderRepository.DeletaTodoRepositorio(DiretorioConsolidar);

                ViewBag.UploadStatus = UploadFolderRepository.UploadDeArquivos($"{DiretorioConsolidar}/Uploads", files);


                // ----------------------------------------
                // Extraí as informações dos bloco 0200 e C170

                FileInfo arquivoSped = ArquivoSped.RetornaArquivoSpedNoRepositorio($"{DiretorioConsolidar}/Uploads");

                IEnumerable<string> BlocoC170 = LayoutArquivoSped.RetornaConsultaDoBloco(arquivoSped.FullName, "|C170|");
                IEnumerable<string> Bloco0200 = LayoutArquivoSped.RetornaConsultaDoBloco(arquivoSped.FullName, "|0200|");

                List<Bloco0200> bloco0200 = LayoutArquivoSped.RetornaOsRegistrosdoBloco0200(Bloco0200);
                List<BlocoC170> blocoC170 = LayoutArquivoSped.RetornaOsRegistrosdoBlocoC170(BlocoC170);

                List<BlocoC170> listaFinalBlocoC170 = LayoutArquivoSped
                    .RetornaListadoBlocoC170ComDescricao(bloco0200, blocoC170);

                // --------------------------------------
                // Extraí as chaves das notas do arquivo sped

                IFiles Ifiles = AbstractFiles
                    .RetornaExtensaoArquivo(arquivoSped.Extension);

                // 
                //var listaDeNotas = Ifiles
                //    .RetornaListaDeNotasFiscaisBaixadas(
                //    $"{diretorioConsolidar}/Notas/NotasBaixadas",
                //    arquivoSped.FullName,
                //    "entrada");



                //var listaNotasQueNaoExistem = listaDeNotas
                //  .ToList()
                //  .FindAll(x => x.Existe == false);

                //if (listaNotasQueNaoExistem.Any())
                //{
                //    return RedirectToAction("RelatorioDeNotasFiscaisBaixadas", "Analise");
                //}

                //C:\Users\Rafael Medeiros\Documents\Arquivos\NotasBaixadas 
                //FileInfo[] caminhoFisicoXmls = UploadFolderRepository.GetAllFilesInDirectory($"{diretorioConsolidar}/Uploads");
                FileInfo[] caminhoFisicoXmls = UploadFolderRepository
                    .GetAllFilesInDirectory(@"C:\Users\Rafael Medeiros\Documents\Arquivos\NotasBaixadas");


                IList<string> PathDeXmls = LayoutNotaFiscal.VerificaLayoutNotaFiscal(caminhoFisicoXmls);


                NotaFiscalProduto.ConsolidarNotas(
               PathDeXmls,
               listaFinalBlocoC170,
               Cnpj);




                //if (listaConsolidada.Any())
                //{
                //    return View("~/Areas/Restrito/Views/Analise/Consolidacao.cshtml", listaConsolidada);
                //}

                // 0 - Entrada
                // 1- Saída
                // Baixar Notas de Saída
            }

            return View();

        }

    }
}