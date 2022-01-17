using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Download
{
    public static class NotasFiscais
    {

        public static Dictionary<string, string> DefineNomeclaturaParaArquivoQueSeraCompactado(string usuario, string diretorio)
        {
            Dictionary<string, string> infoArquivoZipado = new Dictionary<string, string>
            {
                {"DiretorioNotas", $"{diretorio}/Notas"},
                {"DiretorioTemporario", $"{diretorio}/Temp//NotasBaixadas_{DateTime.Now.ToString("dd-MM-yyyy")}.zip" },
                {"Nome", $"NotasBaixadas_{DateTime.Now.ToString("dd-MM-yyyy")}.zip" }
            };

            return infoArquivoZipado;
        }
    }
}
