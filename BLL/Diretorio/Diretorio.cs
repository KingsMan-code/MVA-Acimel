using System.IO;
using System.Linq;

namespace DAL
{
    public static class Diretorio
    {

        public static string[] RetornaTodosOsXmlsNoDiretorio(string pasta)
        {
            return Directory.GetFiles(pasta, "*.xml", SearchOption.AllDirectories);
        }

        public static int DeveRetornarTodasAsXmlsNoDiretorio(string diretorio)
        {
            return Directory.GetFiles(
                $"{diretorio}",
                "*.xml",
                SearchOption.AllDirectories)
                .Count();
        }

        public static int DeveQuantidadeDeNotasNaoBaixadas(string diretorio)
        {
            try
            {
                int contador = 0;

                string log = Directory.GetFiles($"{diretorio}", "*.txt").FirstOrDefault();

                if(!string.IsNullOrEmpty(log))
                {
                    contador = File.ReadAllLines(log).Count();
                }

                return contador;

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
