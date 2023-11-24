using AutoMapper;
using GlobalSolution.Areas.Identity.Data.DTOs;
using GlobalSolution.Models;

namespace GlobalSolution.Profiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
          CreateMap<CriarFeedbackDto, Feedback>();
          CreateMap<AtualizarFeedbackDto, Feedback>();
          CreateMap<Feedback, AtualizarFeedbackDto>();
          CreateMap<Feedback, LerFeedbackDto>();

        }
    }
}
