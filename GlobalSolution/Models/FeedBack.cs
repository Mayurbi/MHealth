namespace GlobalSolution.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Mensagem { get; set; }
        [Required]
        public string UsuarioId { get; set; }
        [Required]
        public DateTime DataEnvio { get; set; }

    }
}
