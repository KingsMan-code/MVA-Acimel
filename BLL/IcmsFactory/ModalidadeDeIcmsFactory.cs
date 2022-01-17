
using DAL.IcmsFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ModalidadeDeIcmsFactory
    {

        private static IDictionary<string, IModalidadeDeIcms>
            ListaDeModalidades = new Dictionary<string, IModalidadeDeIcms>();
 
        public static IModalidadeDeIcms RetornaModalidadeDeIcms(string tipoDeIcms)
        {
            // Lazy Loading 
            if (ListaDeModalidades.Count == 0)
            {
                ListaDeModalidades.Add("ICMS00", new Icms00Factory());
                ListaDeModalidades.Add("ICMS10", new Icms10Factory());
                ListaDeModalidades.Add("ICMS20", new Icms20Factory());
                ListaDeModalidades.Add("ICMS30", new Icms30Factory());
                ListaDeModalidades.Add("ICMS40", new Icms40Factory());
                ListaDeModalidades.Add("ICMS41", new Icms41Factory());
                ListaDeModalidades.Add("ICMS50", new Icms50Factory());
                ListaDeModalidades.Add("ICMS51", new Icms51Factory());
                ListaDeModalidades.Add("ICMS60", new Icms60Factory());
                ListaDeModalidades.Add("ICMS70", new Icms70Factory());
                ListaDeModalidades.Add("ICMS90", new Icms90Factory());
                ListaDeModalidades.Add("ICMSPart", new ICMSPartFactory());
                ListaDeModalidades.Add("ICMSST", new ICMSSTFactory());
                ListaDeModalidades.Add("ICMSSN101", new ICMSSN101Factory());
                ListaDeModalidades.Add("ICMSSN102", new ICMSSN102Factory());
                ListaDeModalidades.Add("ICMSSN201", new ICMSSN201Factory());
                ListaDeModalidades.Add("ICMSSN202", new ICMSSN202Factory());
                ListaDeModalidades.Add("ICMSSN500", new ICMSSN500Factory());
                ListaDeModalidades.Add("ICMSSN900", new ICMSSN900Factory());
        
            }
            // Replace if with Poly
            return ListaDeModalidades[tipoDeIcms];
        }

    }
}
