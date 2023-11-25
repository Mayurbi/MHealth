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
        public string Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
       /// public bool? Ativo { get; internal set; }
    }
}