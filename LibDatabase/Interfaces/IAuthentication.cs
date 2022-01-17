using DAL.Database;

namespace LibDatabase.Interfaces
{
    public interface IAuthentication
    {
        Acesso CheckLogin(string usuario, string senha);
        bool Logout();
    }
}
