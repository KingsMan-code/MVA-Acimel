using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOTAS.Models
{
    public class FilesName
    {
        [Required(ErrorMessage = "Por favor, selecione um arquivo.")]
        [Display(Name = "*.*")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}