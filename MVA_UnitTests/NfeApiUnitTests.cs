using NOTAS.Metodos.Download;
using NOTAS.Metodos.TxtFile;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{
    [TestFixture]
    public class NfeApiUnitTests
    {

        [TestCase(@"C:\Users\Rafael Medeiros\Documents\Arquivos\notas.txt",
            @"C:\Users\Rafael Medeiros\Documents\Arquivos\Uploads")]
        public void DeveVerificaSeNotaExisteNaNfstock(string input, string diretorio)
        {

            List<NOTAS.Models.Notas> Notas = new List<NOTAS.Models.Notas>();

            Notas = TxtComChaves.RetonaChaves(input);

            NfStockAPI.BaixarNotas(diretorio, Notas);

            Assert.AreEqual(46, System.IO.Directory.GetFiles(@"C:\Users\Rafael Medeiros\Documents\Arquivos\Uploads\Notas\\NotasBaixadas\2018\12").Count());

        }
    }
}
