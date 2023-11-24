using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("Usuario")]
    public class Usuario : IdentityUser
    {
        [Key]
        [Required]
        public override string? Id { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        public override string? Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string?  Password { get; set; }
    }
}