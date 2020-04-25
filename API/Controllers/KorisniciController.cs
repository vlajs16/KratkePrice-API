using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects.KorisnikDTOs;
using Logics.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisnikLogic _logic;
        private readonly IMapper _mapper;

        public KorisniciController(IKorisnikLogic logic, IMapper mapper)
        {
            _logic = logic;
            _mapper = mapper;
        }
        // GET: api/Korisnici
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var korisnici = await _logic.GetObjects();
            if (korisnici == null)
                return NotFound();

            var korisniciZaVracanje = _mapper.Map<List<KorisnikForResultDTO>>(korisnici);

            return Ok(korisniciZaVracanje);
        }
    }
}
