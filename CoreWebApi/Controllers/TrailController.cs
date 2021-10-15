using AutoMapper;
using CoreWebApi.Models;
using CoreWebApi.Models.Dtos;
using CoreWebApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/trail")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "TrailDoc")]
    public class TrailController : Controller
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;
        public TrailController(ITrailRepository trailRepository, IMapper mapper)
        {
            _trailRepository = trailRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Trails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTrails()
        {
            var trailDto = _trailRepository.GetTrails().ToList().Select(_mapper.Map<Trail, TrailsDto>);
            return Ok(trailDto);
        }
        /// <summary>
        /// Get Single Trail
        /// </summary>
        /// <param name="trailId"></param>
        /// <returns></returns>
        [HttpGet("{trailId:int}", Name = "GetTrail")]
        public IActionResult GetTrail(int trailId)
        {
            var trailIndb = _trailRepository.GetTrail(trailId);
            if (trailIndb == null)
                return NotFound();
            var trailDto = _mapper.Map<TrailsDto>(trailIndb);
            return Ok(trailDto);
        }
        
        [HttpGet("[action]/{nationalParkId:int}", Name ="GetTrailsByNationalPark")]
        public IActionResult GetTrailsByNationalPark(int nationalParkId)
        {
            if (nationalParkId == 0)
                return NotFound();
            var trailDto = _trailRepository.GetTrailsByNationalPark(nationalParkId).
                Select(_mapper.Map<Trail, TrailsDto>);
            if (trailDto == null)
                return NotFound();
            return Ok(trailDto);
        }
        /// <summary>
        /// Save Trail
        /// </summary>
        /// <param name="trailUpsertDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTrails([FromBody] TrailUpsertDto trailUpsertDto)
        {
            if (trailUpsertDto == null)
                return BadRequest();
            if (_trailRepository.TrailExists(trailUpsertDto.Name))
            {
                ModelState.AddModelError("", "National Park already In DB");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var trail = _mapper.Map<Trail>(trailUpsertDto);
            if (!_trailRepository.CreateTrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong whole save data:{trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            //return Ok();
            return CreatedAtRoute("GetTrail", new { trailId = trail.Id }, trailUpsertDto);
        }
        /// <summary>
        /// Update Trail
        /// </summary>
        /// <param name="TrailId"></param>
        /// <param name="trailUpsertDto"></param>
        /// <returns></returns>
        [HttpPut ("{TrailId:int}")]
        public IActionResult UpdateTrails(int TrailId, [FromBody] TrailUpsertDto trailUpsertDto)
        {
            if (TrailId == 0)
                return BadRequest();
            if (TrailId != trailUpsertDto.id || trailUpsertDto == null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var trail = _mapper.Map<Trail>(trailUpsertDto);
            if (!_trailRepository.UpdateTrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong while update data:{trail.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            //return NoContent();
            return CreatedAtRoute("GetTrail", new { trailId = trail.Id }, trail);
        }
        /// <summary>
        /// Delete Trails
        /// </summary>
        /// <param name="trailId"></param>
        /// <returns></returns>
        [HttpDelete("{trailId:int}")]
        public IActionResult DeleteTrails(int trailId)
        {
            if (trailId == 0)
                return BadRequest(StatusCodes.Status400BadRequest);
            var trailInDb = _trailRepository.GetTrail(trailId);
            if (trailInDb == null)
                return NotFound(StatusCodes.Status404NotFound);
            if (!_trailRepository.DeleteTrail(trailInDb))
            {
                ModelState.AddModelError("", $"Something went wrong while delete data:{trailInDb.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }
    }
}
