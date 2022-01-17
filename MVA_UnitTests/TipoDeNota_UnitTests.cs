using DAL;
using DAL.Layout;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MVA_UnitTests
{
    [TestFixture]
    class InformacoesDaEmpresa_UnitTests
    {

        List<string> ListaDeXmls = new List<string>();

        [TestCase(@"C:\LITO\02901843000194\Nfe_33161202901843000194550010000647341333186765.xml", "29323367001604")]
        public void Deve_Retornar_Um_XmlDocument_Com_As_Informacoes_Dos_Produtos(string xmlPath, string cnpj)
        {
            XmlDocument doc = XmlDocumentObject.RetornaXmlDocument(xmlPath);

            Assert.IsNotEmpty(doc);

            // Determina se a nota é de entrada ou saida, para trazer as informações do Cliente / Fornecedor     
            EmpresaModel empresa = DeterminaTipoDeNota.RetornaInformacoesDaEmpresa(doc, cnpj);

            Assert.IsTrue(empresa == null);
        }

        [TestCase("O valor total da saída: R$ 1.091,56 é maior do que a entrada: R$ 200,00")]
        public void Deve_Analisar_Notas_De_Entrada_E_Saida_Teste_Singular(string expetected)
        {

            ListaDeXmls.Add(@"C:\Users\Rafael Medeiros\Desktop\NFEs_Recebidas_01-07-2018-31-07-2018_\Saida\7067777000112\xml\00185364_00000001_07067777000112-nfe.xml");
            ListaDeXmls.Add(@"C:\Users\Rafael Medeiros\Desktop\NFEs_Recebidas_01-07-2018-31-07-2018_\Entrada\7067777000112\xml\13180708775944000142550050000735781000880135-nfe.xml");

            // Pasta as XMLS de entrada e saída juntamento com o CNPJ da empresa
            //var valorDaOperacao = NotaFiscalProduto.ConsolidarNotas(ListaDeXmls, "07067777000112");

           // Assert.AreEqual(expetected, valorDaOperacao);

        }

        [Test]
        public void Deve_Analisar_Notas_De_Entrada_E_Saida_Automatizado()
        {

            List<string> notas = System.IO.Directory.GetFiles(
                @"C:\Users\Rafael Medeiros\Desktop\NFEs_Recebidas_01-07-2018-31-07-2018_", 
                "*.xml",
                System.IO.SearchOption.AllDirectories).ToList();

           // var valorDaOperacao = NotaFiscalProduto.ConsolidarNotas(notas, "07067777000112");


        }






    }




}
