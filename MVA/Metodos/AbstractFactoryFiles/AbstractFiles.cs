using System.Collections.Generic;

namespace NOTAS.Metodos.AbstractFactoryFiles
{
    public static class AbstractFiles
    {
        private static Dictionary<string, IFiles> fileDictionary = new Dictionary<string, IFiles>();

        public static IFiles RetornaExtensaoArquivo(string input)
        {
            if (fileDictionary.Count == 0)
            {
                fileDictionary.Add(".txt", new ArquivoTexto());
                //fileDictionary.Add(".xml", new ArquivoXml());
                //fileDictionary.Add(".xls", new ArquivoXls());
                //fileDictionary.Add(".xlsx", new ArquivoXlsx());
            }

            return fileDictionary[input];
        }


    }
}