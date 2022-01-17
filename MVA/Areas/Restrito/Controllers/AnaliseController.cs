using BLL.Download;
using DAL;
using DAL.Model;
using NOTAS.Metodos.AbstractFactoryFiles;
using NOTAS.Models;
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
    public class AnaliseController : Controller
    {

        public static List<Notas> listaDeNotasNaoBaixadas = null;
        public static IList<NotaAnalise> listaDeProdutos = null;
        public static IList<Notas> listaDeNotas = null;
        public static string Usuario = string.Empty;
        public static string DiretorioAnalise = string.Empty;
        public static string Cnpj = string.Empty;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadArquivosRepositorioAnalise(HttpPostedFileBase[] files)
        {

            if (ModelState.IsValid)
            {

                listaDeNotas = new List<Notas>();

                Usuario = Session["nomeUsuarioLogado"].ToString();
                DiretorioAnalise = Server.MapPath($"~/UploadedFiles/{Usuario}/Analise");
                Cnpj = Session["Cnpj"].ToString();

                UploadFolderRepository.DeletaTodoRepositorio(DiretorioAnalise);

                var fileUploadedInRepository = files
                    .Select(x => Path.GetExtension(x.FileName))
                    .FirstOrDefault();


                if (fileUploadedInRepository.Contains(".xml"))
                {
                    ViewBag.UploadStatus = UploadFolderRepository
                        .UploadDeArquivos($"{DiretorioAnalise}/Notas/NotasBaixadas", files);
                }
                else
                {

                    ViewBag.UploadStatus = UploadFolderRepository
                         .UploadDeArquivos($"{DiretorioAnalise}/Uploads", files);


                    foreach (var item in UploadFolderRepository.GetAllFilesInDirectory($"{DiretorioAnalise}/Uploads"))
                    {
                        IFiles Ifiles = AbstractFiles.RetornaExtensaoArquivo(item.Extension);
                        listaDeNotas = Ifiles.RetornaListaDeNotasFiscaisBaixadas(DiretorioAnalise, item.FullName, "");
                    }


                    if (listaDeNotas.Any())
                    {
                        var listaNotasQueNaoExistem = listaDeNotas
                          .ToList()
                          .FindAll(x => x.Existe == false);

                        if (listaNotasQueNaoExistem.Any())
                        {
                            listaDeNotasNaoBaixadas = listaNotasQueNaoExistem;
                            return RedirectToAction("RelatorioDeNotasFiscaisBaixadas", "Analise");
                        }
                    }

                }

                var repositorioNotasFiscais = UploadFolderRepository.GetAllFilesInDirectory($"{DiretorioAnalise}/Notas/NotasBaixadas");
                IList<string> ListaNotasValidas = LayoutNotaFiscal.VerificaLayoutNotaFiscal(repositorioNotasFiscais);

                listaDeProdutos = NotaFiscalProduto.ColetarInformacoes(ListaNotasValidas, Cnpj);
                return View("~/Areas/Restrito/Views/Analise/Visualizar.cshtml", listaDeProdutos);
            }

            return View();
        }

        [HttpGet]
        public FileContentResult SolicitarRelatorioDeAnalise()
        {

            string[] ColumnNames =
             {
                "CHAVE",
                "NÚMERO",
                "FORNECEDOR / CLIENTE",
                "CNPJ",
                "CÓDIGO DO PRODUTO",
                "DESCRIÇÃO DO PRODUTO / SERVIÇO",
                "EAN/GTIN",
                "NCM/SH",
                "O/CST",
                "CFOP",
                "UN",
                "QUANT VALOR",
                "VALOR UNIT",
                "VALOR DOS PRODUTOS",
                
                "B.CÁLC ICMS",
                "VALOR ICMS",
                "VALOR IPI",
                "ALÍQ. ICMS",
                "ALÍQ. IPI",

                "ALÌQ. FUNDO DE COMBATE À POBREZA",
                "ALÍQ. ICMSST",

                "BASE DE CÁLC. ICMST S.T.",
                "VALOR DO ICMS SUBST.",

                "MVA NF-e",

                "FRETE",
                "SEGURO",
                "DESCONTO",
                "OUTRAS DESPESAS",

                "VALOR TOTAL",
                "BASE ICMS ST (BENEFÍCIO)",
                "ICMS ST (BENEFÍCIO)",
            };

            byte[] filecontent = ExcelExportHelper.ExportExcel(listaDeProdutos, "", true, ColumnNames);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "MVA_" + DateTime.Now + ".xlsx");

        }

        [HttpGet]
        public ActionResult RelatorioDeNotasFiscaisBaixadas()
        {
            ViewBag.NotasBaixadas = Diretorio.DeveRetornarTodasAsXmlsNoDiretorio($"{DiretorioAnalise}/Notas/NotasBaixadas");
            ViewBag.Canceladas = Diretorio.DeveRetornarTodasAsXmlsNoDiretorio($"{DiretorioAnalise}/Notas/NotasCanceladas");
            ViewBag.NotasNaoEncontradas = listaDeNotasNaoBaixadas.Count().ToString();

            return View(listaDeNotasNaoBaixadas);
        }

        [HttpGet]
        public FilePathResult DownloadDasNotas()
        {
            Dictionary<string, string> zipFileConfig = NotasFiscais.DefineNomeclaturaParaArquivoQueSeraCompactado(Usuario, DiretorioAnalise);

            string dirRaiz = zipFileConfig["DiretorioNotas"];
            string dirTemporario = zipFileConfig["DiretorioTemporario"];
            string nomeArquivo = zipFileConfig["Nome"];

            ZipFile.CreateFromDirectory(dirRaiz, dirTemporario, CompressionLevel.Optimal, true);

            return File(dirTemporario, "application/zip", nomeArquivo);
        }
    }
}