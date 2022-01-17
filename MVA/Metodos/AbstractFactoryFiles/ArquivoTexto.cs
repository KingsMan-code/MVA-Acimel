using NOTAS.Metodos.Download;
using NOTAS.Metodos.SpedFile;
using NOTAS.Metodos.TxtFile;
using NOTAS.Models;
using System.Collections.Generic;

namespace NOTAS.Metodos.AbstractFactoryFiles
{
    public class ArquivoTexto : IFiles
    {
  
        public List<Notas> RetornaListaDeNotasFiscaisBaixadas(string diretorio, string filePath, string parametro)
        {
            _ = new List<Notas>();

            bool hasSpeedFile = LayoutSped.ValidaLayout(filePath);
            List<Notas> listaDeChaves;

            if (hasSpeedFile)
            {
                var chaves = ArquivoSped.RetonaChaves(filePath, parametro);
                listaDeChaves = NfStockAPI.BaixarNotas(diretorio, chaves);
            }
            else
            {
                var chaves = TxtComChaves.RetonaChaves(filePath);
                listaDeChaves = NfStockAPI.BaixarNotas(diretorio, chaves);
            }

            return listaDeChaves;
        }
    }
}