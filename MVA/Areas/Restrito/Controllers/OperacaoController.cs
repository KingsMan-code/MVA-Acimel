using DAL;
using DAL.Database;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVA.Areas.Restrito.Controllers
{
    [Authorize]
    public class OperacaoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Empresa> listaDeEmpresa = EmpresaRepositoyBLL.RetornaListaDeEmpresa();

            ViewBag.Cnpj = new SelectList
                (
                  listaDeEmpresa,
                  "Cnpj",
                  "RazaoSocial"
                );

            return View();
        }

        [HttpPost]
        public ActionResult Selecionar(FormCollection Collection)
        {

            if (ModelState.IsValid)
            {

                Session["Cnpj"] = Collection["Cnpj"].ToString();
                Session["Modulo"] = Collection["radio"];

                string Modulo = Session["Modulo"].ToString();

                switch (Modulo)
                {
                    case "analise":
                        return RedirectToAction("Index", "Analise");

                    case "consolidar":
                        return RedirectToAction("Index", "Consolidar");

                    case "baixarNotas":
                        return RedirectToAction("Index", "BaixarNotas");

                    default:
                        ModelState.AddModelError("", "Você precisa selecionar uma operação antes de continuar!");
                        return View();
                }
            }
           
            return View();
        }

    }
}