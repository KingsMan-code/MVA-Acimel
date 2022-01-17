using System.Linq;

namespace NOTAS.Metodos.SpedFile
{
    public static class LayoutSped
    {

        public static bool ValidaLayout(string file)
        {
           return System.IO.File.ReadLines(file).Take(1).Any(x => x.StartsWith("|0000|"));
        }

    }
}
