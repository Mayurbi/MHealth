using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Nome is required")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "FoiAceito is required")]
        public Boolean FoiAceito { get; set; }
        [Required(ErrorMessage = "NivelDor is required")]
        public int NivelDor { get; set; }
        [Required(ErrorMessage = "LocalDor is required")]
        public string LocalDor { get; set; }
        [Required(ErrorMessage = "TipoMedicacao is required")]
        public string TipoMedicacao { get; set; }
        [Required(ErrorMessage = "Temperatura is required")]
        public string Temperatura { get; set; }
        [Required(ErrorMessage = "Acompanhante is required")]
        public string Acompanhante { get; set; }
        [Required(ErrorMessage = "TipoComida is required")]
        public string TipoComida { get; }
        public string Status { get; internal set; }
    }
}
