using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("Enfermeira")]
    public class Enfermeira : Usuario
    {
        [Key]
        [Required]
        public long id { get; set; }
        [Required]
        public string coren { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string dataNasc { get; set; }
    }
}
