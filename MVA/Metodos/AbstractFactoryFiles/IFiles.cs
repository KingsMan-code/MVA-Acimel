using NOTAS.Models;
using System.Collections.Generic;

namespace NOTAS.Metodos.AbstractFactoryFiles
{
    public interface IFiles
    {
        List<Notas> RetornaListaDeNotasFiscaisBaixadas(string diretorio, string filePath, string parametro);
    }
}