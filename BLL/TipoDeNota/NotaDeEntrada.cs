using DAL.Layout;
using System.Xml;

namespace DAL
{
    public class NotaDeEntrada : ITipoDeNota
    {
 
        // Fornecedor
        // 0 - Entrada
        public EmpresaModel RetornaEmpresa(XmlDocument doc, string cnpj)
        {

            var empresa = new EmpresaModel();

            var cnpjDestinatario = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/dest/CNPJ", "0");

            if (!cnpj.Equals(cnpjDestinatario))
            {
                empresa.RazaoSocial = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/dest/xNome", "0");
                empresa.Cnpj = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/dest/CNPJ", "0");
            }

            return empresa;
        }
    }
}
