using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("Paciente")]
    public class Paciente 
    {
        [Key]
        [Required]
        public string nome { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string dataNasc { get; set; }
        [Required]
        public Prontuario prontuario { get; set; }
    }
}
