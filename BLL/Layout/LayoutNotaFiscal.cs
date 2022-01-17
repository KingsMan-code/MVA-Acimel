using DAL.Layout;
using DAL.Model;
using DAL.Model.LayoutXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace DAL
{
    public static class LayoutNotaFiscal
    {

        static XmlDocument doc = null;
        static object lockedObject = new object();
        static IList<string> listaDeXmlsValidas = null;

        /// <summary>
        /// Verifica se a nota fiscal corresponde ao layout de entrada
        /// </summary>
        /// <param name="notas"></param>
        /// <returns></returns>
        public static IList<string> VerificaLayoutNotaFiscal(FileInfo[] notas)
        {

            doc = new XmlDocument();
            listaDeXmlsValidas = new List<string>();
            notas.ToList().AsParallel().ForAll(nota =>
            {
                lock (lockedObject)
                {
                    if (nota.Extension.Contains(".txt"))
                    {
                        return;
                    }

                    // Carrega a nota fiscal
                    doc.Load(nota.FullName);

                    // Verifica se existe a tag 'prod' na xml 
                    // essa tag é responsável pelas informações do produto
                    if (VerificaSeExisteTagProduto(doc) == true)
                    {
                        listaDeXmlsValidas.Add(nota.FullName);
                    };
                }
            });

            return listaDeXmlsValidas;
        }

        /// <summary>
        ///  Verifica se a nota fiscal possuí a tag 'prod' referente ao produto
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private static bool VerificaSeExisteTagProduto(XmlDocument document)
        {
            return (document.GetElementsByTagName("prod") == null) ? false : true;
        }

        public static NotaAnalise RetornaInformacoesDaNota(XmlNode produto, IDictionary<string, string> dictionaryIcmsLayout)
        {

            NotaAnalise nota = new NotaAnalise
            {

                cProd = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/cProd", "0"), // Código do Produto
                xProd = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/xProd", "0"), // Descrição do Produto
                cEAN = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/cEAN", "0"), // EAN
                NCM = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/NCM", "0"), // NCM
                CST = Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "CST"), // CST
                CFOP = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/CFOP", "0"), // CFOP
                uCom = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/uCom", "0"), // Unidade Comercial
                qCom = Validacao.RetornaValorUnitarioFormatado(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/qCom", "0")), // Quantidade Comercial
                vProd = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/vProd", "0")), // Valor do Produto
                vUnCom = Validacao.RetornaValorUnitarioFormatado(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/vUnCom", "0")), // Valor Unidade Comercial

                ICMS_vBC = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vBC")), // Valor Base de Cálculo ICMS
                ICMS_vICMS = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vICMS")), // Valor ICMS
                ICMS_pICMS = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "pICMS")), // Aliquota ICMS
                ICMS_vICMSST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vICMSST")), // VALOR DO ICMS SUBST.
                ICMS_vBCST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vBCST")), //  BASE DE CÁLC. ICMST S.T.

                pICMSST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "pICMSST")),
                pFCP = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "pFCP")),
                 
       
        Mva_Nfe = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "pMVAST")),

                IPI_vIPI = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//imposto/IPI/IPITrib/vIPI", "0,00")), // Valor do IPI
                IPI_pIPI = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//imposto/IPI/IPITrib/pIPI", "0,0")),  // AliquotaIPI

                Frete = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/vFrete", "0,0")),

            };



            return nota;
        }

        public static NotaConsolidada RetornaNotaConsolidada(XmlNode produto, IDictionary<string, string> dictionaryIcmsLayout)
        {

            NotaConsolidada nota = new NotaConsolidada
            {


                cProd = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/cProd", "0"), // Código do Produto
                xProd = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/xProd", "0"), // Descrição do Produto
                cEAN = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/cEAN", "0"), // EAN
                NCM = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/NCM", "0"), // NCM
                CST = Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "CST"), // CST
                CFOP = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/CFOP", "0"), // CFOP
                uCom = Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/uCom", "0"), // Unidade Comercial
                qCom = Validacao.RetornaValorUnitarioFormatado(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/qCom", "0")), // Quantidade Comercial
                vProd = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/vProd", "0")), // Valor do Produto
                vUnCom = Validacao.RetornaValorUnitarioFormatado(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/vUnCom", "0")), // Valor Unidade Comercial

                ICMS_vBC = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vBC")), // Valor Base de Cálculo ICMS
                ICMS_vICMS = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vICMS")), // Valor ICMS

                ICMS_pICMS = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "pICMS")), // Aliquota ICMS

                ICMS_vICMSST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vICMSST")), // VALOR DO ICMS SUBST.
                ICMS_vBCST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(dictionaryIcmsLayout, "vBCST")), //  BASE DE CÁLC. ICMST S.T.

                IPI_vIPI = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//imposto/IPI/IPITrib/vIPI", "0,00")), // Valor do IPI
                IPI_pIPI = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//imposto/IPI/IPITrib/pIPI", "0,0")),  // AliquotaIPI

                Frete = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(produto, ".//prod/vFrete", "0,0")),
            };

            return nota;
        }

    }
}
