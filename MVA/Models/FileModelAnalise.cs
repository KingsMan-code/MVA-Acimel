using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVA.Models
{
    public class FileModelAnalise
    {
        [Required(ErrorMessage = "Por favor, selecione um arquivo.")]
        [Display(Name = "*.txt")]

        public HttpPostedFileBase[] Files { get; set; }
    }
}