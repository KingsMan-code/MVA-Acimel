using DAL;
using System.Xml;

namespace DAL
{
    public interface ITipoDeNota
    {
        EmpresaModel RetornaEmpresa(XmlDocument doc, string cnpj);
    }
}
