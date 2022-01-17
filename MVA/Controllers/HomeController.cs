using DAL;
using DAL.Database;
using LibDatabase.Repositories;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVA.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Acesso acesso)
        {
            if (ModelState.IsValid)
            {
                UserAuthentication authentication = new UserAuthentication();
                var user = authentication.CheckLogin(acesso.Usuario, acesso.Senha);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Usuario, true);
                    Session["usuarioLogadoID"] = user.Id.ToString();
                    Session["nomeUsuarioLogado"] = user.Usuario.ToString();

                    return RedirectToAction("Index", "Operacao", new { area = "Restrito" });
                }

                ModelState.AddModelError("", "Usuário ou Senha Incorretos!");

                return View();
            }
            return View();
        }
    }
}