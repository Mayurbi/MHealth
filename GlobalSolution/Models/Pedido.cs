using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public Usuario Usuario { get; set; }
        [Required]
        public Boolean FoiAceito { get; set; }
        [Required]
        public int NivelDor { get; set; }
        [Required]
        public string LocalDor { get; set; }
        [Required]
        public string TipoMedicacao { get; set; }
        [Required]
        public string Temperatura { get; set; }
        [Required]
        public string Acompanhante { get; set; }
        [Required]
        public string TipoComida { get; }

    }
}
