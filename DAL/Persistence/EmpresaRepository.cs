using DAL.Model;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class EmpresaRepository : AbstractRepository<Empresa, int>
    {

        public override void Deletar(Empresa entity)
        {
            throw new NotImplementedException();
        }
        public override void DeletarPorCodigo(int id)
        {
            throw new NotImplementedException();
        }
        public override List<Empresa> ListarEmpresas()
        {
            using (MvaAcesso db = new MvaAcesso())
            {
                return db.Empresas.ToList();
            }
        }
        public override Empresa RetornaEmpresaPorCodigo(int id)
        {
            using (MvaAcesso db = new MvaAcesso())
            {
                return db.Empresas.Where(x => x.IdEmpresa == id).FirstOrDefault();
            }
        }

        public override void Atualizar(Empresa entity)
        {
            using (MvaAcesso db = new MvaAcesso())
            {
                var _empresa = db.Empresas.Single(x => x.IdEmpresa == entity.IdEmpresa);

                _empresa.RazaoSocial = entity.RazaoSocial;
                _empresa.Cnpj = entity.Cnpj;
                _empresa.Aliquota = entity.Aliquota;

                db.SaveChanges();
            }
        }

        public override void Cadastrar(Empresa entity)
        {

            using (MvaAcesso db = new MvaAcesso())
            {

                var hasExistEmpresa = db.Empresas.Any(x => x.Cnpj == entity.Cnpj);

                if (hasExistEmpresa == true)
                {
                    return;
                }

                Empresa empresa = new Empresa
                {
                    RazaoSocial = entity.RazaoSocial,
                    Cnpj = entity.Cnpj,
                    Aliquota = entity.Aliquota
                };

                // Save changes
                db.Empresas.Add(empresa);
                db.SaveChanges();
            }
        }

        public int RetornaEmpresaPorCnpj(string cnpj)
        {

            using (MvaAcesso db = new MvaAcesso())
            {
                int aliquota = 0;

                var hasCnpjExist = db.Empresas.Any(x => x.Cnpj == cnpj);

                if (hasCnpjExist)
                {
                    aliquota = (int)db.Empresas
                        .Where(x => x.Cnpj == cnpj)
                        .Select(x => x.Aliquota).FirstOrDefault();

                }

                return aliquota;
            }
        }
    }
}
