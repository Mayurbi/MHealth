using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("Prontuario")]
    public class Prontuario
    {
        [Key]
        [ForeignKey("Paciente")] 
        public long PacienteId { get; set; }
        [Required]
        public string Receitas { get; set; }
        [Required]
        public string Relatorios { get; set; }
        [Required]
        public Paciente Paciente { get; set; }

    }
}
