using DAL;
using DAL.Layout;
using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL.TipoDeNota
{
    public static class Modalidade
    {

        public static EmpresaModel RetornaModalidade(XmlDocument doc, string cnpj)
        {

            EmpresaModel empresa = new EmpresaModel();

            var cnpjEmitente = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/emit/CNPJ", "0");
            var cnpjDestinatario = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/dest/CNPJ", "0");


            if (cnpj.Equals(cnpjEmitente))   // Cliente igual emitente = Saída
            {
                empresa.RazaoSocial = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/emit/xNome", "0");
                empresa.Cnpj = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/emit/CNPJ", "0");
                empresa.TipoNotaFiscal = "saida";

            }
            else if (cnpj.Equals(cnpjDestinatario))  // Cliente igual destinatário = Entrada
            {
                empresa.RazaoSocial = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/dest/xNome", "0");
                empresa.Cnpj = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/dest/CNPJ", "0");
                empresa.TipoNotaFiscal = "entrada";
            }

            return empresa;

        }

    }
}
