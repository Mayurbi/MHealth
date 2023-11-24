using AutoMapper;
using GlobalSolution.Areas.Identity.Data.DTOs;
using GlobalSolution.Models;

namespace GlobalSolution.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CriarUserDto, Usuario>();
            CreateMap<AtualizarUserDto, Usuario>();
            CreateMap<Usuario, AtualizarUserDto>();
            CreateMap<Usuario, LerUserDto>();
        }

    }
}