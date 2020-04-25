using DataAccessLayer;
using Domain;
using Helpers;
using Logics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class PitanjaLogic : IPitanjaLogic
    {
        private readonly PriceContext _context;

        public PitanjaLogic(PriceContext context)
        {
            _context = context;
        }
        public async Task<List<Pitanje>> GetObjects()
        {
            try
            {
                var pitanja = await _context.Pitanja.Include(x => x.Odgovori).ToListAsync();
                return pitanja;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> " + ex.Message);
                return null;
            }
        }

        public async Task<double> SavePoints(List<Pitanje> pitanja, int korisnikID)
        {
            try
            {
                var pitanjaIzBaze = await _context.Pitanja.Include(p => p.Odgovori).ToListAsync();
                if (pitanjaIzBaze == null)
                    return -500;
                if (pitanjaIzBaze.Count != pitanja.Count)
                    return -500;

                var poeni = pitanjaIzBaze.CalculatePoints(pitanja);

                var korisnik = await _context.Korisnici.FirstOrDefaultAsync(x => x.KorisnikID == korisnikID);
                if (korisnik == null)
                    return -500;

                korisnik.Poeni = poeni;
                korisnik.DatumUcesca = DateTime.Now;

                await _context.SaveChangesAsync();
                return poeni;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> " + ex.Message);
                return -500;
            }
        }
    }
}
