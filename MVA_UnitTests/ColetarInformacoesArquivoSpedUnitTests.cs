using BLL.Layout;
using DAL.Model.Blocos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{
    [TestFixture]
    public class ColetarInformacoesArquivoSpedUnitTests
    {

        // C:\Users\Rafael Medeiros\Documents\Arquivos
        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarOBlocoC170(string input)
        {
            IEnumerable<string> BlocoC170 = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|C170|");

            Assert.IsNotNull(BlocoC170);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarNulloQuandoNaoExistirBloco(string input)
        {
            IEnumerable<string> BlocosNullos = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|C0070|");

            Assert.IsNull(BlocosNullos);
        }

        // C:\Users\Rafael Medeiros\Documents\Arquivos
        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarOBloco0200(string input)
        {
            IEnumerable<string> Bloco0200 = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|0200|");
            Assert.IsNotNull(Bloco0200);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarosRegistrosdoBloco0200(string input)
        {
            IEnumerable<string> Bloco0200 = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|0200|");
            List<Bloco0200> bloco0200 = LayoutArquivoSped.RetornaOsRegistrosdoBloco0200(Bloco0200);

            Assert.IsNotEmpty(bloco0200);
            Assert.AreEqual(4515, bloco0200.Count);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarosRegistrosdoBlocoC170(string input)
        {

            IEnumerable<string> BlocoC170 = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|C170|");
            List<BlocoC170> blocoC170 = LayoutArquivoSped.RetornaOsRegistrosdoBlocoC170(BlocoC170);

            Assert.IsNotEmpty(blocoC170);
            Assert.AreEqual(6780, blocoC170.Count);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarBlocoC170ComDescricao(string input)
        {

            IEnumerable<string> BlocoC170 = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|C170|");
            IEnumerable<string> Bloco0200 = LayoutArquivoSped.RetornaConsultaDoBloco(input, "|0200|");

            List<Bloco0200> bloco0200 = LayoutArquivoSped.RetornaOsRegistrosdoBloco0200(Bloco0200);
            List<BlocoC170> blocoC170 = LayoutArquivoSped.RetornaOsRegistrosdoBlocoC170(BlocoC170);

            List<BlocoC170> listaFinalBloco0200 = LayoutArquivoSped.RetornaListadoBlocoC170ComDescricao(bloco0200, blocoC170);

            Assert.IsNotEmpty(listaFinalBloco0200);
            Assert.AreEqual(6780, listaFinalBloco0200.Count);
        }

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\SPED.txt")]
        public void DeveRetornarAsChavesDoBlocoC100(string input)
        {

            List<BlocoC100> listaBlocoC100 = new List<BlocoC100>();

            listaBlocoC100 = LayoutArquivoSped.RetornaChavesBlocoC100(input);

            Assert.IsNotEmpty(listaBlocoC100);

            Assert.AreEqual(4683, listaBlocoC100.Count);

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Rafael Medeiros\Documents\Arquivos\notas.txt"))
            //{
            //    foreach (var item in listaBlocoC100)
            //    {
            //        file.WriteLine(item.CHV_NFE); 
            //    }
            //}
        }
    }
}
