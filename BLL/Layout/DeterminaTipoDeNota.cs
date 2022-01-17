
using DAL;
using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Layout
{
    public class DeterminaTipoDeNota
    {

        public static EmpresaModel RetornaInformacoesDaEmpresa(XmlDocument doc, string cnpj)
        {

            int tipoDeNota = int.Parse(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/ide/tpNF", "0"));

            ITipoDeNota iTipoDeNota = FactoryTipoDeNota.RetornaTipoDeNota(tipoDeNota);

            EmpresaModel EmpresaModel = iTipoDeNota.RetornaEmpresa(doc, cnpj);

            return EmpresaModel;
        }

        public static List<NotaConsolidada> DeterminaTipoNota(IList<NotaConsolidada> Lista, string input)
        {
            return (from notas in Lista
                    where notas.TipoNotaFiscal.Equals(input)
                    select notas).ToList();
        }
    }
}
