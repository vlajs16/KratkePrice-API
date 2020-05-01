using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects.PricaDTOs;
using Logics.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceLogic _price;
        private readonly IMapper _mapper;

        public PriceController(IPriceLogic price, IMapper mapper)
        {
            _price = price;
            _mapper = mapper;
        }
        // GET: api/price
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var price = await _price.GetObjects();
            if (price == null)
                return NotFound();

            var priceToReturn = _mapper.Map<List<PricaForListDTO>>(price);
            return Ok(priceToReturn);
        }

        // GET: api/price/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prica = await _price.GetById(id);
            if (prica == null)
                return NotFound();

            var pricaToReturn = _mapper.Map<PricaForDetailsDTO>(prica);
            return Ok(pricaToReturn);
        }

        // GET: api/price/{id}/{next}
        [HttpGet("{id}/{next}")]
        public async Task<IActionResult> Get(int id, bool next)
        {
            var prica = await _price.Wanted(id,next);
            if (prica == null)
                return NotFound("Priča nije pronađena");

            return Ok(prica.PricaID);
        }


        // POST: api/Price
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
