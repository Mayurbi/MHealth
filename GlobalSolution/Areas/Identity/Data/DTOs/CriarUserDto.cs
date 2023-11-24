using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Areas.Identity.Data.DTOs
{
    public class CriarUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nome is required")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Telefone is required")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "DataNasc is required")]
        public string dataNasc { get; set; }
     
    }
}
