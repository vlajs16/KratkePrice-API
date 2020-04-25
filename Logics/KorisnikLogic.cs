using DataAccessLayer;
using Domain;
using Logics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class KorisnikLogic : IKorisnikLogic
    {
        private readonly PriceContext _context;

        public KorisnikLogic(PriceContext context)
        {
            _context = context;
        }
        public async Task<List<Korisnik>> GetObjects()
        {
            try
            {
                DateTime weekStart, weekEnd;
                CalculateWeekDays(out weekStart, out weekEnd);

                var korisnici = await _context.Korisnici
                    .Where(x => x.DatumUcesca >= weekStart && x.DatumUcesca <= weekEnd)
                    .Take(5).OrderByDescending(x => x.Poeni).ToListAsync();

                return korisnici;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>> " + ex.Message);
                return null;
            }
        }

        private void CalculateWeekDays(out DateTime weekStart, out DateTime weekEnd)
        {
            DateTime baseDate = DateTime.Now;
            weekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            weekEnd = weekStart.AddDays(7).AddSeconds(-1);
        }
    }
}
