using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Areas.Identity.Data.DTOs
{
    public class LerUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string dataNasc { get; set; }
    }
}
