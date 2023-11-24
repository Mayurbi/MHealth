using AutoMapper;
using GlobalSolution.Areas.Identity.Data;
using GlobalSolution.Areas.Identity.Data.DTOs;
using GlobalSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private MySQLContext _context;
        private IMapper _mapper;

        public FeedbackController(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SendFeedback([FromBody] CriarFeedbackDto feedbackDto)
        {
            Feedback feedback = _mapper.Map<Feedback>(feedbackDto);

            _context.Feedbacks.Add(feedback);

            _context.SaveChanges();

            return Ok(_mapper.Map<List<LerFeedbackDto>>(_context.Feedbacks));
        }

        [HttpGet]
        public IEnumerable<LerFeedbackDto> GetAllFeedbacks()
        {
            return _mapper.Map<List<LerFeedbackDto>>(_context.Feedbacks);
        }
    }

}

