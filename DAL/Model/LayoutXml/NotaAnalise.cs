using DAL.Database;
using DAL.Model.LayoutXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Model
{

    public class NotaAnalise
    {

    
        // NFE
        public string cNF { get; set; }  // CHAVE
        public int nNF { get; set; }  // NUMERO

        // FORNECEDOR / CLIENTE
        public string Cliente { get; set; }  // FORNECEDOR / CLIENTE
        public string Cnpj { get; set; } // CNPJ

        // PRODUTO
        public string cProd { get; set; }  // CODIO DO PRODUTO
        public string xProd { get; set; } // DESCRIÇÃO DO PRODUTO / SERVIÇO
        public string cEAN { get; set; }  // EAN / GTIN
        public string NCM { get; set; }  // NCM / SH
        public string CST { get; set; } // O/CST
        public string CFOP { get; set; } // CFOP
        public string uCom { get; set; } //  UN
        public string qCom { get; set; }  // QUANT VALOR
        public string vUnCom { get; set; }  // VALOR UNITÁRIO
        public string vProd { get; set; }  // VALOR  DOS PRODUTOS

        // ICMS
        public string ICMS_vBC { get; set; } // VALOR BASE DE CÁLCULO - ICMS
        public string ICMS_vICMS { get; set; } // VALOR DO ICMS - ICMS
        public string IPI_vIPI { get; set; }  // VALOR DO IPI - IPI
        public string ICMS_pICMS { get; set; } // ALIQUOTA DO ICMS 
        public string IPI_pIPI { get; set; }  // ALIQUOTA DO IPI
                                              //
        public string pFCP { get; set; } // ALIQUOTA DO FUNDO DE COMBATE À POBREZA 
        public string pICMSST { get; set; }  // ALIQUOTA DO ICMSST
        //
        public string ICMS_vBCST { get; set; } // VALOR BASE DE CALCULO ST
        public string ICMS_vICMSST { get; set; }  // VALOR ICMS ST

        public string Mva_Nfe { get; set; }  // VALOR MVA

        // OUTROS VALORES
        public string Frete { get; set; }  // FRETE
        public string Seguro { get; set; }  // SEGURO
        public string Descontos { get; set; } // DESCONTO
        public string OutrasDespesas { get; set; }  // OUTRAS DESPESAS

        // CÁLCULOS
        public string ValorTotal { get; set; }  //  VALOR TOTAL
        public string BaseIcmsStBeneficio { get; set; } // VALOR BASE ST
        public string IcmsStBeneficio { get; set; }  // VALOR ICMS ST


    }

}
