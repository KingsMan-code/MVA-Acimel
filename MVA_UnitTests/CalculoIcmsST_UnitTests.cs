using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{
    [TestFixture]
    public class CalculoIcmsST_UnitTests
    {

        [TestCase("2.421,22", "20", "210,54")]
        public void Deve_Retorna_O_Calculo_IcmsSt(string baseIcmsStBeneficio, decimal aliquotaInterna, string valorIcms)
        {
            var srt = IcmsST.Calculo(baseIcmsStBeneficio, aliquotaInterna, valorIcms);

            Assert.That("273,70", Is.EqualTo(srt));
        }

    }
}
