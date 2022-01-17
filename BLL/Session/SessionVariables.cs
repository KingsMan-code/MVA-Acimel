using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace BLL.Session
{
    public class SessionVariables
    {
  
        public static void SaveSession()
        {

        }

        public static HttpSessionState ReturnSession()
        {
            return (HttpSessionState)System.Web.HttpContext.Current.Session["nomeUsuarioLogado"];
        }

    }
}
