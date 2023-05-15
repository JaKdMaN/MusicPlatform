using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly ITrackRepository _trackRepository;

        public CommentController(ICommentRepository commentRepository, IMapper mapper, ITrackRepository trackRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _trackRepository = trackRepository;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateComment([FromQuery] int trackId, [FromBody] CreateCommentDto createCommentDto)
        {
            if (createCommentDto == null)
                return BadRequest(ModelState);

            var commentMap = _mapper.Map<Comment>(createCommentDto);

            commentMap.Track = _trackRepository.GetTrack(trackId);

            if (!_commentRepository.CreateComment(commentMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
