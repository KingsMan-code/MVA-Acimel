using DAL.Database;
using LibDatabase.Interfaces;
using System;
using DAL;
using System.Linq;

namespace LibDatabase.Repositories
{
    public class UserAuthentication : IAuthentication
    {
      
        public Acesso CheckLogin(string usuario, string senha)
        {
            MvaAcesso mvaAcesso = new MvaAcesso(); 

            return mvaAcesso
                .Acessoes
                .Where(a => a.Usuario.Equals(usuario) && a.Senha.Equals(senha))
                .FirstOrDefault();
        }


        public bool Logout()
        {
            return true;
        }
    }
}
