using DataAccessLayer;
using Domain;
using Logics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class AuthLogic : IAuthLogic
    {
        private readonly PriceContext _context;

        public AuthLogic(PriceContext context)
        {
            _context = context;
        }
        public async Task<bool> ProveraPostojecih(string email, string telefon, string korisnickoIme)
        {
            try
            {
                Korisnik korisnik = null;
                if (!string.IsNullOrEmpty(telefon))
                {
                    korisnik = await _context.Korisnici
                    .FirstOrDefaultAsync(x => x.Email == email || x.Telefon == telefon || x.KorisnickoIme == korisnickoIme);
                }
                else
                {
                    korisnik = await _context.Korisnici
                    .FirstOrDefaultAsync(x => x.Email == email || x.KorisnickoIme == korisnickoIme);
                }
                if (korisnik == null)
                    return false;
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>>> " + ex.Message);
                return true;
            }
        }

        public async Task<Korisnik> Register(Korisnik korisnik)
        {
            try
            {
                await _context.Korisnici.AddAsync(korisnik);
                await _context.SaveChangesAsync();
                return korisnik;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>>> " + ex.Message);
                return null;
            }
        }
    }
}
