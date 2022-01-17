using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FactoryTipoDeNota
    {

        private static Dictionary<int, ITipoDeNota> tipoDeNotas = new Dictionary<int, ITipoDeNota>();

        public static ITipoDeNota RetornaTipoDeNota(int tipo)
        {

            if(tipoDeNotas.Count == 0)
            {
                tipoDeNotas.Add(0, new NotaDeEntrada());
                tipoDeNotas.Add(1, new NotaDeSaida());
            }

            return tipoDeNotas[tipo];

        }

    }
}
