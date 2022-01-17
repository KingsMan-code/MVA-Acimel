using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public abstract class AbstractRepository<TEntity, Tkey>
        where TEntity : class
    {
        public abstract List<TEntity> ListarEmpresas();
        public abstract TEntity RetornaEmpresaPorCodigo(Tkey id);
        public abstract void Cadastrar(TEntity entity);
        public abstract void Atualizar(TEntity entity);
        public abstract void Deletar(TEntity entity);
        public abstract void DeletarPorCodigo(Tkey id);
    }
}
