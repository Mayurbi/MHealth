namespace GlobalSolution.Areas.Identity.Data.DTOs
{
    public class LerPedidoDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public Boolean FoiAceito { get; set; }
        public int NivelDor { get; set; }
        public string LocalDor { get; set; }
        public string TipoMedicacao { get; set; }
        public string Temperatura { get; set; }
        public string Acompanhante { get; set; }
        public string TipoComida { get; }
    }
}
