using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Areas.Identity.Data.DTOs
{
    public class AtualizarUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nome is required")]
        public string telefone { get; set; }
    }
}
