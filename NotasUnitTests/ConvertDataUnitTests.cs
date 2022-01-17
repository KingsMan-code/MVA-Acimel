using NOTAS.Metodos.Data;
using NOTAS.Metodos.JSON;
using NOTAS.Metodos.Xml;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NotasUnitTests
{
    [TestFixture]
    public class ConvertDataUnitTests
    {

        [TestCase(@"C:\Projetos\Projeto Especiais\Notas\NOTAS\Xml\nota.txt")]
        public void Deve_Deserializar_Xml(string input)
        {
            string xmlSource = System.IO.File.ReadAllText(input);
            string xmlDeserializado = Json.Deserializar(xmlSource);
            Assert.IsNotNull(xmlDeserializado);
        }


        [TestCase(@"C:\Projetos\Projeto Especiais\Notas\NOTAS\Xml\nota.txt")]
        public void Deve_Retornar_Data_Do_Xml_Deserializado(string input)
        {
            string xmlSource = System.IO.File.ReadAllText(input);
            string xmlDeserializado = Json.Deserializar(xmlSource);

            XmlDocument xml = XmlDocumentObject.RetornaXmlDocument(xmlDeserializado);

            var data = xml.SelectSingleNode(".//ide/dhEmi").InnerText;
            Assert.IsNotNull(xmlDeserializado);
        }


        [TestCase("2018-02-08T15:15:03-02:00")]
        public void Deve_Converter_Data_Do_Xml_Para_MMYY_E_Fazer_O_Split(string input)
        {
            string[] data = ConverterData.Formatar(input).Split('/');

            string diretorio = @"C:\example\" + $"{data[2]}\\{data[1]}\\{data[0]}";

            Assert.IsNotNull(data);
            Assert.IsNotEmpty(diretorio);

        }



    }
}
