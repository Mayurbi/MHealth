using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Areas.Identity.Data.DTOs
{
    public class CriarPedidoDto
    {
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
    }
}
