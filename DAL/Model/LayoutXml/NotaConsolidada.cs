namespace DAL.Model.LayoutXml
{
    public class NotaConsolidada 
    {
        
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
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
        public string ICMS_vBCST { get; set; } // VALOR BASE DE CALCULO ST
        public string ICMS_vICMSST { get; set; }  // VALOR ICMS ST

        // OUTROS VALORES
        public string Frete { get; set; }  // FRETE
        public string Seguro { get; set; }  // SEGURO
        public string Descontos { get; set; } // DESCONTO
        public string OutrasDespesas { get; set; }  // OUTRAS DESPESAS

        public string TipoNotaFiscal { get; set; }
        public string Mva { get; set; }
        public string Markup { get; set; }
        public string ResultadoConsolidacao { get; set; }



    }
}
