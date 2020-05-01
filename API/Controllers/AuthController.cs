using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects.KorisnikDTOs;
using Domain;
using Logics.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthLogic _logic;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthController(IAuthLogic logic, IMapper mapper, IConfiguration config)
        {
            _logic = logic;
            _mapper = mapper;
            _config = config;
        }

        // POST: api/auth/register
        //[HttpPost("register")]
        //public async Task<IActionResult> Post([FromBody] KorisnikToRegisterDTO korisnik)
        //{
        //    korisnik.Email = korisnik.Email.ToLower().Trim();
        //    korisnik.KorisnickoIme = korisnik.KorisnickoIme.ToLower().Trim();
        //    if (korisnik.Telefon.ToString() != "")
        //        korisnik.Telefon = korisnik.Telefon.ToLower().Trim();
        //    else korisnik.Telefon = null;

        //    if (await _logic.ProveraPostojecih(korisnik.Email, korisnik.Telefon, korisnik.KorisnickoIme))
        //        return BadRequest("Korisnik sa ovim parametrima vec postoji");

        //    var korisnikZaRegistraciju = _mapper.Map<Korisnik>(korisnik);

        //    var registrovanKorisnik = await _logic.Register(korisnikZaRegistraciju);

        //    if (registrovanKorisnik == null)
        //        return BadRequest("Trenutno nije moguce registrovati se");

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, registrovanKorisnik.KorisnikID.ToString()),
        //        new Claim(ClaimTypes.Name, registrovanKorisnik.KorisnickoIme)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.
        //        GetBytes(_config.GetSection("AppSettings:Token").Value));

        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.Now.AddDays(1),
        //        SigningCredentials = creds
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    return Ok(new { token = tokenHandler.WriteToken(token) });
        //}   

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromForm] KorisnikToRegisterDTO korisnik)
        {
            var korisnikZaRegistraciju = _mapper.Map<Korisnik>(korisnik);
            korisnikZaRegistraciju.Email = korisnik.Email.ToLower().Trim();
            korisnikZaRegistraciju.KorisnickoIme = korisnik.KorisnickoIme.ToLower().Trim();
            if (korisnikZaRegistraciju.Telefon != null)
                korisnikZaRegistraciju.Telefon = korisnik.Telefon.ToLower().Trim();
            else korisnikZaRegistraciju.Telefon = null;

            if (await _logic.ProveraPostojecih(korisnikZaRegistraciju.Email, korisnikZaRegistraciju.Telefon, korisnikZaRegistraciju.KorisnickoIme))
                return BadRequest("Korisnik sa ovim parametrima vec postoji");

            

            var registrovanKorisnik = await _logic.Register(korisnikZaRegistraciju);

            if (registrovanKorisnik == null)
                return BadRequest("Trenutno nije moguce registrovati se");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, registrovanKorisnik.KorisnikID.ToString()),
                new Claim(ClaimTypes.Name, registrovanKorisnik.KorisnickoIme)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
