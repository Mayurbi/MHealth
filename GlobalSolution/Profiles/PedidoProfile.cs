using AutoMapper;
using GlobalSolution.Areas.Identity.Data.DTOs;
using GlobalSolution.Models;

namespace GlobalSolution.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<CriarPedidoDto, Pedido>();
            CreateMap<AtualizarPedidoDto, Pedido>();
            CreateMap<Pedido, AtualizarPedidoDto>();
            CreateMap<Pedido, LerPedidoDto>();

        }
    }
}
