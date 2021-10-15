using AutoMapper;
using CoreWebApi.Models;
using CoreWebApi.Models.Dtos;
using CoreWebApi.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/NationalPark")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiExplorerSettings(GroupName ="NPDoc")]
    
    
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalPark;
        private readonly IMapper _mapper;
         public NationalParkController(INationalParkRepository nationalPark,IMapper mapper)
        {
            _nationalPark = nationalPark;
            _mapper = mapper;
        }
        /// <summary>
        /// Get National Park
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var nationalParkListDto = _nationalPark.GetNationalParks().ToList().Select(_mapper.Map<NationalPark, NationalParkDto>); 
            //var nationalParkDtoList = new List<NationalParkDto>();
            //foreach(var nationalPark in nationalParkList)
            //{
            //    nationalParkDtoList.Add(_mapper.Map<NationalPark, NationalParkDto>(nationalPark));
            //  nationalParkDtoList.Add(_mapper.Map<NationalParkDto>(nationalPark));
            //}
            return Ok(nationalParkListDto); //200
        }
        /// <summary>
        /// Get National By ID
        /// </summary>
        /// <param name="nationalParkId"></param>
        /// <returns></returns>
        [HttpGet("{nationalParkId:int}",Name ="GetNationalPark")]
        public IActionResult GetNationalPark(int nationalParkId)
        {
            var nationalPark = _nationalPark.GetNationalPark(nationalParkId);
            if (nationalPark == null)
                return NotFound();
            var nationalParkDto = _mapper.Map<NationalParkDto>(nationalPark);
            return Ok(nationalParkDto);
        }
        /// <summary>
        /// Add New National Park
        /// </summary>
        /// <param name="nationalParkDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateNationalPark([FromBody]NationalParkDto nationalParkDto)
        {
               if (nationalParkDto == null)
                return BadRequest(ModelState);
            if (_nationalPark.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park already In DB");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalPark.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong whole save data:{nationalPark.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            //return Ok();
            return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalPark.Id }, nationalPark);

        }
        /// <summary>
        /// Update National Park
        /// </summary>
        /// <param name="nationalParkId"></param>
        /// <param name="nationalParkDto"></param>
        /// <returns></returns>
        [HttpPut("{nationalParkId:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateNationalPark(int nationalParkId,[FromBody]NationalParkDto nationalParkDto)
        {
            if (nationalParkId != nationalParkDto.Id || nationalParkDto == null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var nationalPrk = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalPark.UpdateNationalPark(nationalPrk))
            {
                ModelState.AddModelError("", $"Something went wrong while update data:{nationalPrk.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
            //return CreatedAtRoute("GetNationalPark", new { nationalParkId = nationalPrk.Id }, nationalPrk);
        }
        /// <summary>
        /// Delete National Park
        /// </summary>
        /// <param name="nationalParkId"></param>
        /// <returns></returns>
       [HttpDelete]
       public IActionResult DeleteNationalPark(int nationalParkId)
       {
            if (nationalParkId == 0)
                return BadRequest(StatusCodes.Status400BadRequest);
            var nationalPrkInDb = _nationalPark.GetNationalPark(nationalParkId);
            if (nationalPrkInDb == null)
                return NotFound(StatusCodes.Status404NotFound);
            if (!_nationalPark.DeleteNationalPark(nationalPrkInDb))
            {
                ModelState.AddModelError("", $"Something went wrong while delete data:{nationalPrkInDb.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
       }
        
    }
}
