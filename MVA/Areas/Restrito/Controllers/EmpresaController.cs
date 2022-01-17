using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVA.Areas.Restrito.Controllers
{

    [Authorize]
    public class EmpresaController : Controller
    {
   
        public ActionResult Index()
        {
            return View(EmpresaRepositoyBLL.RetornaListaDeEmpresa());
        }

        // GET: Empresa/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                // Logica pra salvar
                EmpresaRepositoyBLL.CadastrarEmpresa(empresa);

                return RedirectToAction("Index");
            }
            else
            {
                return View(empresa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {

            var empresa = EmpresaRepositoyBLL.RetornaEmpresaPorCodigo(id);

            if (empresa == null)
            {
                return HttpNotFound();

            }

            return View(empresa);
        }

        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                EmpresaRepositoyBLL.AtualizarEmpresa(empresa);

                return RedirectToAction("Index");
            }
            else
            {
                return View(empresa);
            }
        }

        [HttpPost]
        public ActionResult Excluir()
        {
            return View();
        }

    }
}