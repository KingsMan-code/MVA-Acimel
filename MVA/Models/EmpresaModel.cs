using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVA.Models
{
    public class EmpresaModel
    {
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage ="O campo Razão Social é obrigatório.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Alíquota é obrigatório.")]
        public decimal Aliquota { get; set; }
    }
}