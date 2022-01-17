

using BLL.CalculoAnaliseMva;
using BLL.CalculoConsolidador;
using BLL.Calculos;
using BLL.TipoDeNota;
using DAL.Layout;
using DAL.Model;
using DAL.Model.Blocos;
using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace DAL
{

    public static class NotaFiscalProduto
    {

        private static string ValorTotal { get; set; }
        private static object objectLocked = new object();
        private static decimal aliquotaInterna = 0;

        public static IList<NotaAnalise> ColetarInformacoes(IList<string> pathDeNotas, string cnpj)
        {

            IList<NotaAnalise> listaNotasFiscais = new List<NotaAnalise>();

            // Recebe uma lista de XMLS e inicia um loop para carregá-las
            // uma à uma no XmlDocument
            foreach (var pathXml in pathDeNotas)
            {

                XmlDocument doc = XmlDocumentObject.RetornaXmlDocument(pathXml);

                // Verifica se o XML é nulo
                if (doc == null)
                {
                    continue;
                }

                // Realiza a busca no banco de dados para aplicar o valor do MVA
                string _aliquota = EmpresaRepositoyBLL.RetornaAliquotaPorEmpresa(cnpj).ToString() ?? "0";
                aliquotaInterna = Convert.ToDecimal(_aliquota);

                // Determina se a nota é de entrada ou saida, para trazer as informações do Cliente / Fornecedor     
                EmpresaModel empresa = DeterminaTipoDeNota.RetornaInformacoesDaEmpresa(doc, cnpj);

                // Retorna os atributos do node IDE da Nota Fiscal 
                // número da nota fiscal e chave nota fiscal
                var _cNF = Validacao.CheckIfNodeIsNullOrEmpty(doc, "//protNFe/infProt/chNFe", "0");
                var _nNF = int.Parse(Validacao.CheckIfNodeIsNullOrEmpty(doc, "//NFe/infNFe/ide/nNF", "0"));

                // ICMS Total
                var _frete = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vFrete", "0"));
                var _seguro = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vSeg", "0"));
                var _desconto = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vDesc", "0"));
                var _outrasDespesas = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vOutro", "0"));

                // Seleciona o node destinatário e retorna um array de nodes
                XmlNodeList xmlProdutoList = doc.SelectNodes("//NFe/infNFe/det");

                // Loop para cada item dentro do node destinatário
                // aqui já estamos trazendo os atributos de cada produto dentro da nota
                foreach (XmlNode produto in xmlProdutoList)
                {

                    if (produto == null)
                    {
                        continue;
                    }

                    // Retorna o atual subnode do ICMS no XML    
                    IDictionary<string, string> IcmsLayoutDicionario = IcmsNode.RetornaIcmsNode(produto);

                    // Retorna as informações do XML
                    NotaAnalise notaFiscal = LayoutNotaFiscal.RetornaInformacoesDaNota(produto, IcmsLayoutDicionario);

                    // Adiciona as informações à lista
                    notaFiscal.Cliente = empresa.RazaoSocial;
                    notaFiscal.Cnpj = empresa.Cnpj;
                    notaFiscal.cNF = _cNF;
                    notaFiscal.nNF = _nNF;
                    //notaFiscal.Frete = _frete;
                    notaFiscal.Seguro = _seguro;
                    notaFiscal.Descontos = _desconto;
                    notaFiscal.OutrasDespesas = _outrasDespesas;

                    // Realiza o cálculo da base ICMS ST
                    string baseIcmsStBeneficio = BaseIcmsST.Calculo(notaFiscal, aliquotaInterna);

                    // pICMSST
                    // mostrar no relatorio sem calculo
                    string _pICMSST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(IcmsLayoutDicionario, "pICMSST"));
                    notaFiscal.pICMSST = _pICMSST;

                    // pFCP
                    string _pFCP = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(IcmsLayoutDicionario, "pFCP"));
                    notaFiscal.pFCP = _pFCP;

                    // Cálculo para o valor do ICMS + Valor do Fundo de Combate à Pobreza
                    string _vImcs = notaFiscal.ICMS_vICMS;  // 50.70
                    string _vFcp = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(IcmsLayoutDicionario, "vFCP"));
                    notaFiscal.ICMS_vICMS = CalculaFcp.CalculaValorICMSeValorFundoCombatePobreza(_vImcs, _vFcp);

                    //
                    // Cálculo para o valor da Aliquota do ICMSST + Percentual do Fundo de Combate à pobreza retido por Substituição Tributária
                    string _pIcmsCstSt = notaFiscal.ICMS_pICMS;
                    string _pFCPST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(IcmsLayoutDicionario, "pFCPST"));
                    notaFiscal.ICMS_pICMS = CalculaFcp.CalculaAliquotaImpostoIcmsStePercentualFcpSubTributaria(_pIcmsCstSt, _pFCPST);

                    //
                    // Cálculo para o valor do ICMSST + Valor do Combate à pobreza retido por Substituição Tributária
                    string _vIcmsCst = notaFiscal.ICMS_vICMSST;
                    string _vbCFCPST = Validacao.RetornaValorDecimal(Validacao.CheckIfDictionaryValueExists(IcmsLayoutDicionario, "vFCPST"));
                    notaFiscal.ICMS_vICMSST = CalculaFcp.CalculaValorICMSSTeFundoCombatePobrezaSubstituicaoTributaria(_vIcmsCst, _vbCFCPST);


                    // Realiza o cálculo do ICMS ST
                    string resultadoCalculoIcmsSt = IcmsST.Calculo(baseIcmsStBeneficio, 20, notaFiscal.ICMS_vICMS);

                    // Valor Total
                    notaFiscal.ValorTotal = CalculaValorTotal.Calculo(notaFiscal);

                    // Resultado Base ST
                    notaFiscal.BaseIcmsStBeneficio = baseIcmsStBeneficio;

                    // Resultado ICMS ST
                    notaFiscal.IcmsStBeneficio = resultadoCalculoIcmsSt;

                    // Adiciona à lista de produtos
                    listaNotasFiscais.Add(notaFiscal);
                }
            }

            return listaNotasFiscais;

        }

        public static void ConsolidarNotas(IList<string> caminhoFisicoNotasFiscaisSaida, List<BlocoC170> listaNotasFiscaisEntrada, string cnpj)
        {

            List<ResultadoFinalMva> listaMva = new List<ResultadoFinalMva>();
            List<NotaConsolidada> listaNotasFiscaisDeSaida = new List<NotaConsolidada>();

            foreach (var pathXml in caminhoFisicoNotasFiscaisSaida)
            {

                XmlDocument doc = XmlDocumentObject.RetornaXmlDocument(pathXml);

                // Verifica se o XML é nulo
                if (doc == null)
                {
                    continue;
                }

                // Realiza a busca no banco de dados para aplicar o valor do MVA
                string _aliquota = EmpresaRepositoyBLL.RetornaAliquotaPorEmpresa(cnpj).ToString() ?? "0";
                aliquotaInterna = Convert.ToDecimal(_aliquota);

                EmpresaModel empresa = Modalidade.RetornaModalidade(doc, cnpj);

                // Retorna os atributos do node IDE da Nota Fiscal 
                // número da nota fiscal e chave nota fiscal
                var _cNF = Validacao.CheckIfNodeIsNullOrEmpty(doc, "//protNFe/infProt/chNFe", "0");
                var _nNF = int.Parse(Validacao.CheckIfNodeIsNullOrEmpty(doc, "//NFe/infNFe/ide/nNF", "0"));

                // ICMS Total
                //var _frete = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vFrete", "0"));
                var _seguro = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vSeg", "0"));
                var _desconto = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vDesc", "0"));
                var _outrasDespesas = Validacao.RetornaValorDecimal(Validacao.CheckIfNodeIsNullOrEmpty(doc, ".//NFe/infNFe/total/ICMSTot/vOutro", "0"));

                // Seleciona o node destinatário e retorna um array de nodes
                XmlNodeList xmlProdutoList = doc.SelectNodes("//NFe/infNFe/det");

                // Loop para cada item dentro do node destinatário
                // aqui já estamos trazendo os atributos de cada produto dentro da nota
                foreach (XmlNode produto in xmlProdutoList)
                {

                    if (produto == null)
                    {
                        continue;
                    }

                    // Retorna o atual subnode do ICMS no XML    
                    IDictionary<string, string> IcmsLayoutDicionario = IcmsNode.RetornaIcmsNode(produto);

                    // Retorna as informações do XML
                    NotaConsolidada notaFiscal = LayoutNotaFiscal.RetornaNotaConsolidada(produto, IcmsLayoutDicionario);

                    notaFiscal.RazaoSocial = empresa.RazaoSocial;
                    notaFiscal.Cnpj = empresa.Cnpj;
                    notaFiscal.TipoNotaFiscal = empresa.TipoNotaFiscal;
                    // notaFiscal.Frete = _frete;
                    notaFiscal.Seguro = _seguro;
                    notaFiscal.Descontos = _desconto;
                    notaFiscal.OutrasDespesas = _outrasDespesas;

                    // Adiciona à lista de produtos
                    listaNotasFiscaisDeSaida.Add(notaFiscal);

                }

            }

            // MVA -- Entrada
            var NotasDeEntradaComMvaCalculado = ConsolidacaoEntrada
            .RetornaCalculoMva(listaNotasFiscaisEntrada);

            // MarkUp - Saida
            Markup.UnidadeComercial(listaNotasFiscaisDeSaida);




        }

        public static IDictionary<string, string> RetornaDicionarioComIcms(string icms, XmlNode produto)
        {
            IModalidadeDeIcms iModalidade = ModalidadeDeIcmsFactory.RetornaModalidadeDeIcms(icms);
            IDictionary<string, string> iDictionaryIcms = iModalidade.RetornaModalidadeDeIcms(produto);
            return iDictionaryIcms;
        }

        public static decimal RetornaAliquotaPorEmpresa(string cnpj)
        {
            return 0;
        }
    }
}