using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Interfaces;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : Controller
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;

        public TrackController(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Track>))]
        public IActionResult GetTracks()
        {
            var tracks = _trackRepository.GetTracks();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tracks);
        }

        [HttpGet("{trackId}")]
        [ProducesResponseType(200, Type=typeof(Track))]
        [ProducesResponseType(400)]
        public IActionResult GetTrack(int trackId)
        {
            if (!_trackRepository.TrackExists(trackId))
                return NotFound();

            var track = _trackRepository.GetTrack(trackId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(track);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTrack([FromBody] CreateTrackDto trackDto)
        {
            if(trackDto == null)
                return BadRequest(ModelState);

            var trackMap = _mapper.Map<Track>(trackDto);

            trackMap.Listens = 0;

            if (!_trackRepository.CreateTrack(trackMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
