using DAL.Database;
using DAL.Persistence;
using System.Collections.Generic;

namespace DAL
{
    public static class EmpresaRepositoyBLL
    {
        public static List<Empresa> RetornaListaDeEmpresa()
        {
            return new EmpresaRepository().ListarEmpresas();
        }

        public static void CadastrarEmpresa(Empresa empresa)
        {
            new EmpresaRepository().Cadastrar(empresa);
        }

        public static int RetornaAliquotaPorEmpresa(string cnpj)
        {
            return new EmpresaRepository().RetornaEmpresaPorCnpj(cnpj);
        }

        public static Empresa RetornaEmpresaPorCodigo(int id)
        {
            return new EmpresaRepository().RetornaEmpresaPorCodigo(id);
        }

        public static void AtualizarEmpresa(Empresa empresa)
        {
            new EmpresaRepository().Atualizar(empresa);
        }

    }
}
