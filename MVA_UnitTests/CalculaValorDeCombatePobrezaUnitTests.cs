using BLL.CalculoAnaliseMva;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVA_UnitTests
{

    [TestFixture]
    public class CalculaValorDeCombatePobrezaUnitTests
    {

       
        [TestCase("50,70", "5,63")]
        public void Deve_Retornar_Somar_vICMS_e_FCP(string vImcs, string vFcp)
        {
            var str = CalculaFcp.CalculaValorICMSeValorFundoCombatePobreza(vImcs, vFcp);
            Assert.AreEqual("56,33", str);

        }

        [TestCase("18,0000", "2,0000")]
        public void Deve_Retornar_Soma_AliquotaIcmsSt_e_Percentual_Fundo_Combate_Pobreza(string pIcmsSt, string pFcpSt)
        {
            var str = CalculaFcp.CalculaAliquotaIcmsePercentualFundoCombatePobreza(pIcmsSt, pFcpSt);
            Assert.AreEqual("20", str);

        }

        [TestCase("38,63", "4,29")]
        public void Deve_Retornar_O_Valor_Da_Soma_vICMSST_e_Valor_Do_FCP_Por_Substituicao_Tributaria(string vImcsSt, string vFcpSt)
        {
            var str = CalculaFcp.CalculaValorICMSSTeFundoCombatePobrezaSubstituicaoTributaria(vImcsSt, vFcpSt);
            Assert.AreEqual("42,92", str);

        }

        //[TestCase("18,0000", "2,0000")]
        //public void Deve_Retornar_Soma_Aliquota_Imposto_ICMSST_e_Percentual_FCP_SubstituicaoTributaria(string pIcmsSt, string pFcpSt)
        //{
        //    var str = CalculaFcp.CalculaAliquotaImpostoIcmsStePercentualFcpSubTributaria(pIcmsSt, pFcpSt);
        //    Assert.AreEqual("20", str);

        //}


    }
}
