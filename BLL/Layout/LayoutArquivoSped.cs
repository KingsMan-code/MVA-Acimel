using DAL.Model.Blocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Layout
{
    public class LayoutArquivoSped
    {

        /// <summary>
        ///  Retorna a consulta do bloco passando o caminho do arqui e o nome do bloco
        /// </summary>
        /// <param name="input"></param>
        /// <param name="bloco"></param>
        /// <returns></returns>
        public static IEnumerable<string> RetornaConsultaDoBloco(string input, string bloco)
        {

            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            if (!bloco.Contains("|C170|") && !bloco.Contains("|0200|") && !bloco.Contains("|C100|"))
            {
                return null;
            }

            return System.IO.File.ReadAllLines(input)
                .Where(x => x.StartsWith(bloco));
        }

        /// <summary>
        /// Retorna os itens do bloco 0200 extraidos do arquivo SPED
        /// </summary>
        /// <param name="bloco0200"></param>
        /// <returns></returns>
        public static List<Bloco0200> RetornaOsRegistrosdoBloco0200(IEnumerable<string> IEnumerableBloco0200)
        {

            List<Bloco0200> ListaConsolidadaBloco0200 = new List<Bloco0200>();

            // Tratar o bloco 0200
            var IEnumerableAnonymous0200 = from bl0200 in IEnumerableBloco0200
                                   let splitBlococ0200 = bl0200.Split('|')
                                   select new
                                   {
                                       Codigo = splitBlococ0200[2],
                                       Descricao = splitBlococ0200[3]
                                   };

            foreach (var item in IEnumerableAnonymous0200)
            {
                ListaConsolidadaBloco0200.Add(new Bloco0200
                {
                   COD_ITEM = item.Codigo,
                   DESCR_ITEM = item.Descricao
                });
            }


            return ListaConsolidadaBloco0200;
        }

        /// <summary>
        /// Retorna os itens do bloco c170 extraidos do arquivo SPED
        /// </summary>
        /// <param name="IEnumerableBlocoC170"></param>
        /// <returns></returns>
        public static List<BlocoC170> RetornaOsRegistrosdoBlocoC170(IEnumerable<string> IEnumerableBlocoC170)
        {

            List<BlocoC170> ListaConsolidadaBlocoC170 = new List<BlocoC170>();

            var IEnumerableAnonymousC170 = from bl0C170 in IEnumerableBlocoC170
                                           let splitBlococC170 = bl0C170.Split('|')
                                           select new
                                           {
                                               Cod_Item = splitBlococC170[3],
                                               Vl_Item = splitBlococC170[7],
                                               Vl_Desc = splitBlococC170[8],
                                               Cst_Icms = splitBlococC170[10],
                                               Cfop = splitBlococC170[11],
                                               Cod_Nat = splitBlococC170[12],
                                               Vl_Bc_Icms = splitBlococC170[13],
                                               Aliq_Icms = splitBlococC170[14],
                                               Vl_Icms = splitBlococC170[15],
                                               Vl_Bc_Icms_St = splitBlococC170[16],
                                               Aliq_St = splitBlococC170[17],
                                               Vl_Icms_St = splitBlococC170[18],
                                               Cst_Ipi = splitBlococC170[20],
                                               Vl_Bc_Ipi = splitBlococC170[22],
                                               Aliq_Ipi = splitBlococC170[23],
                                               Vl_Ipi = splitBlococC170[24],
      
                                           };

            foreach (var item in IEnumerableAnonymousC170)
            {
                ListaConsolidadaBlocoC170.Add(new BlocoC170
                {
                    COD_ITEM = item.Cod_Item,
                    DESCR_COMPL = string.Empty,
                    VL_ITEM = item.Vl_Item,
                    VL_DESC = item.Vl_Desc,
                    CST_ICMS = item.Cst_Icms,
                    CFOP = item.Cfop,
                    COD_NAT = item.Cod_Nat,
                    VL_BC_ICMS = item.Vl_Bc_Icms,
                    ALIQ_ICMS = item.Aliq_Icms,
                    VL_ICMS = item.Vl_Icms,
                    VL_BC_ICMS_ST = item.Vl_Bc_Icms_St,
                    ALIQ_ST = item.Aliq_St,
                    VL_ICMS_ST = item.Vl_Icms_St,
                    CST_IPI = item.Cst_Ipi,
                    VL_BC_IPI = item.Vl_Bc_Ipi,
                    ALIQ_IPI = item.Aliq_Ipi,
                    VL_IPI = item.Vl_Ipi,
                });
            }


            return ListaConsolidadaBlocoC170;
        }

        /// <summary>
        /// Retorna a lista do bloco C170 com a descrição do produto do bloco 0200
        /// </summary>
        /// <param name="listaBloco0200"></param>
        /// <param name="listaBloco170"></param>
        public static List<BlocoC170> RetornaListadoBlocoC170ComDescricao(List<Bloco0200> listaBloco0200, List<BlocoC170> listaBloco170)
        {

            List<BlocoC170> ListaFinalBlocoC170 = new List<BlocoC170>();

            foreach (var item in listaBloco170)
            {
               var bloco0200 = listaBloco0200.Find(x => x.COD_ITEM == item.COD_ITEM);
                if(bloco0200 != null)
                {
                    item.DESCR_COMPL = bloco0200.DESCR_ITEM;
                }
            }

            ListaFinalBlocoC170.AddRange(listaBloco170);
            listaBloco170.Clear();

            return ListaFinalBlocoC170;
        }

        /// <summary>
        /// Retorna as chaves do Bloco C100
        /// </summary>
        /// <param name="input"></param>
        public static List<BlocoC100> RetornaChavesBlocoC100(string input)
        {

            List<BlocoC100> ListaBlocoC100 = new List<BlocoC100>();

            // Retorna apenas o blocoC100 do arquivo SPED
           IEnumerable<string> blocoC100 = RetornaConsultaDoBloco(input, "|C100|");

            // Faz o split e retorna apenas o indice de operação e a chave da NFE
            var listaBlocoC100 = from bc100 in blocoC100
                                   let splitbloco = bc100.Split('|')
                                   select new {
                                       IND_OPER = splitbloco[2],
                                       CHV_NFE = splitbloco[9]
                                   };

            // Entrada
            //var blocoC100Entrada = from b in listaBlocoC100
            //                       where b.IND_OPER.Equals("0")
            //                       select b;

            // Saida
            var blocoC100Saida = from b in listaBlocoC100
                                   where b.IND_OPER.Equals("1")
                                   select b;

            foreach (var item in blocoC100Saida)
            {
                ListaBlocoC100.Add(new BlocoC100 {
                    CHV_NFE = item.CHV_NFE
                });
            }

            return ListaBlocoC100;
        }

    }
}
