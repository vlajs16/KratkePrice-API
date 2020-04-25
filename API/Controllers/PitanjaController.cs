using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects.PitanjeDTOs;
using Domain;
using Logics.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/pitanja/user/{korisnikId}")]
    [ApiController]
    public class PitanjaController : ControllerBase
    {
        private readonly IPitanjaLogic _logic;
        private readonly IMapper _mapper;

        public PitanjaController(IPitanjaLogic logic, IMapper mapper)
        {
            _logic = logic;
            _mapper = mapper;
        }
        // GET: api/pitanja/user/{korisnikId}
        [HttpGet]
        public async Task<IActionResult> Get(int korisnikId)
        {
            if (korisnikId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized("Niste prijavljeni za kviz");

            var pitanjaIzBaze = await _logic.GetObjects();
            if (pitanjaIzBaze == null)
                return NotFound();

            var pitanjaZaVracanje = _mapper.Map<List<PitanjeToGetDTO>>(pitanjaIzBaze);

            return Ok(pitanjaZaVracanje);

        }

        // POST: api/pitanja/user/{korisnikId}
        [HttpPost]
        public async Task<IActionResult> Post(int korisnikId, [FromBody] List<PitanjeToReturnDTO> pitanja)
        {
            if (korisnikId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized("Niste prijavljeni za kviz");

            var pitanjaZaProveru = _mapper.Map<List<Pitanje>>(pitanja);

            var poeni = await _logic.SavePoints(pitanjaZaProveru, korisnikId);
            if (poeni == -500)
                return BadRequest("Greska!");

            return Ok(poeni);

        }
    }
}
