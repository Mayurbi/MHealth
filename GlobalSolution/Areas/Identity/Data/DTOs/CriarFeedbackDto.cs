using GlobalSolution.Models;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Areas.Identity.Data.DTOs
{
    public class CriarFeedbackDto
    {
        [Required(ErrorMessage = "Mensagem is required")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "IdUsuario is required")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "DataEnvio is required")]
        public DateTime DataEnvio { get; set; }

    }
}
