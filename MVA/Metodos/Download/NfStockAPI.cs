using NOTAS.Metodos.JSON;
using NOTAS.Metodos.Xml;
using NOTAS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace NOTAS.Metodos.Download
{
    public class NfStockAPI
    {

        public static readonly string baseUrl = "http://192.168.0.23:3000";
        private static readonly object lockObject = new object();

        /// <summary>
        ///  Baixar Notas metódo assyncrono
        /// </summary>
        /// <param name="diretorio"></param>
        /// <param name="listaDeChaves"></param>
        public static List<Notas> BaixarNotas(string diretorio, List<Notas> listaDeChaves)
        {

            List<Notas> ListaDeNotas = new List<Notas>();

            // Retorna lista de notas que existem na NfStock

            List<Notas> taskChavesNotas = CheckNfeAsync(listaDeChaves);


            // Lista com todas as notas que não foram encontradas no webservice da Nfstock
            var listaNotasQueNaoExistem = taskChavesNotas
                .ToList()
                .FindAll(x => x.Existe == false);


            // Lista com todas as notas que retornaram true do servidor da Nfstock
            var listaNotasEncontradas = taskChavesNotas
                .ToList()
                .FindAll(x => x.Existe == true);


            //// Faz a consulta na Nfstock por base das notas que retornaram true na consulta inicial
            List<Notas> TaskNotas = DownloadNfeAsync(diretorio, listaNotasEncontradas);

            listaNotasQueNaoExistem.AddRange(TaskNotas.ToList().FindAll(x => x.Existe == false));

            if (listaNotasQueNaoExistem.Any())
            {
               // Log.WriteLog(diretorio, listaNotasQueNaoExistem);
            }


            ListaDeNotas.AddRange(listaNotasQueNaoExistem);
            ListaDeNotas.AddRange(listaNotasEncontradas);

            return ListaDeNotas;

        }


        private static List<Notas> DownloadNfeAsync(string diretorio, List<Notas> listaDeChaves)
        {

            try
            {
                using (var _httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri(baseUrl);

                    foreach (var chaves in listaDeChaves)
                    {

                        var result = _httpClient.GetStringAsync($"{baseUrl}/getnfe/{chaves.Chave}");

                        if (string.IsNullOrEmpty(result.Result))
                        {
                            chaves.Existe = false;
                            continue;
                        }

                        bool hasConverted = ConvertJsonToXml(diretorio, chaves.Chave, result.Result);

                        if (hasConverted == false)
                        {
                            chaves.Existe = false;
                            continue;
                        }
                    };
                }

            }
            catch
            {
            }

            return listaDeChaves;

        }

        /// <summary>
        ///  Solicita informações à Nfstock de forma assíncrona
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        private static List<Notas> CheckNfeAsync(List<Notas> listaDeChaves)
        {

            try
            {

                using (var _httpClient = new HttpClient())
                {

                    _httpClient.BaseAddress = new Uri(baseUrl);

                    _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    foreach (var chaves in listaDeChaves)
                    {
                        var postResult = _httpClient.GetStringAsync($"{baseUrl}/checknfe/{chaves.Chave}");

                        chaves.Existe = string.IsNullOrEmpty(postResult.Result) ?
                        false : bool.Parse(Newtonsoft.Json.JsonConvert.DeserializeXmlNode(postResult.Result).InnerText);

                    };


                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return listaDeChaves;

        }

        /// <summary>
        ///  Convert JSON to XML
        /// </summary>
        /// <param name="diretorio"></param>
        /// <param name="chave"></param>
        /// <param name="xmlResult"></param>
        /// <returns></returns>
        private static bool ConvertJsonToXml(string diretorio, string chave, string xmlResult)
        {

            XmlDocument xmlDocument = new XmlDocument();
            bool hasConverted = false;
            string diretorioFinal = string.Empty;
            string fileName = string.Empty;

            try
            {
                // Deserializar o JSON com o XML
                string xmlString = Json.Deserializar(xmlResult);

                // Remove os namespaces para pode fazer a pesquisa pelo NODE
                XmlDocument xmlWithReplace = XmlDocumentObject.RetornaXmlDocument(xmlString);

                if (!xmlWithReplace.InnerText.Contains("Cancelamento"))
                {
                    // Retorna o periodo da nota
                    string[] data = Data.ConverterData.Formatar(xmlWithReplace.SelectSingleNode(".//ide/dhEmi").InnerText).Split('/');
                    diretorioFinal = $"{diretorio}\\Notas\\NotasBaixadas\\{data[2]}\\{data[0]}";
                    fileName = $"{chave}-nfe.xml";
                }
                else
                {
                    diretorioFinal = $"{diretorio}\\Notas\\NotasCanceladas";
                    fileName = $"{chave}-cancelada.xml";
                }

                // Verifica se o diretório existe, para poder salvar as notas que serão baixadas
                if (!Directory.Exists(diretorioFinal))
                {
                    Directory.CreateDirectory(diretorioFinal);
                }

                if (File.Exists($"{diretorioFinal}\\{fileName}"))
                {
                    return true;
                }

                xmlDocument.LoadXml(xmlString);
                xmlDocument.Save($"{diretorioFinal}\\{fileName}");

                hasConverted = true;
            }
            catch
            {
                hasConverted = false;
            }

            return hasConverted;
        }

    }
}