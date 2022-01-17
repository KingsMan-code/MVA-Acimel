using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAL;
using DAL.Layout;

namespace DAL
{
    public class NotaDeSaida : ITipoDeNota
    {

        // SAIDA - 1
        public EmpresaModel RetornaEmpresa(XmlDocument doc, string cnpj)
        {

            EmpresaModel empresa = new EmpresaModel();

            var cnpjEmitente = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/emit/CNPJ", "0");

            if (!cnpj.Equals(cnpjEmitente))
            {
                empresa.RazaoSocial = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/emit/xNome", "0");            
                empresa.Cnpj = Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/emit/CNPJ", "0");
            }
       
            return empresa;
        }

   
    }
}
