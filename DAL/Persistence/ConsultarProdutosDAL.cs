using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence
{
    public class ConsultarProdutosDAL
    {

        public List<Produto> ListarProdutos()
        {

            List<Produto> produtos;

            try
            {
                produtos = new ProdutosAuditadosEntities().Produto.AsNoTracking().ToList();
                return produtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                produtos = null;
            }
        }

    }
}
