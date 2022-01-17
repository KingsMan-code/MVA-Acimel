using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpresaModel
    {
        public int IdEmpresa { get; set; } = 0;

        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        public string RazaoSocial { get; set; } = "-";

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public string Cnpj { get; set; } = "-";

        public string TipoNotaFiscal { get; set; } = "-";

        [Required(ErrorMessage = "O campo Alíquota é obrigatório.")]
        public decimal Aliquota { get; set; } = 0;
    }
}
