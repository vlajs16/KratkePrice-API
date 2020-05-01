using DataAccessLayer;
using Domain;
using Logics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logics
{
    public class PriceLogic : IPriceLogic
    {
        private readonly PriceContext _context;

        public PriceLogic(PriceContext context)
        {
            _context = context;
        }
        public async Task<Prica> GetById(int id)
        {
            try
            {
                var prica = await _context.Price.FirstOrDefaultAsync(x => x.PricaID == id);
                return prica;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Prica>> GetObjects()
        {
            try
            {
                var price = await _context.Price.ToListAsync();
                return price;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>>>>> " + ex.Message);
                return null;
            }
        }

        public async Task<Prica> Wanted(int id, bool next)
        {
            if (next)
            {
                return await NextStory(id);
            }
            return await PreviousStory(id);
        }

        private async Task<Prica> PreviousStory(int id)
        {
            var prica = await _context.Price.FirstOrDefaultAsync();
            if (prica.PricaID == id)
                return await _context.Price.OrderByDescending(x => x.PricaID).FirstOrDefaultAsync();
            return await _context.Price.FirstOrDefaultAsync(x => x.PricaID == id - 1);
        }

        private async Task<Prica> NextStory(int id)
        {
            var prica = await _context.Price.OrderByDescending(x => x.PricaID).FirstOrDefaultAsync();
            if (prica.PricaID == id)
                return await _context.Price.FirstOrDefaultAsync();
            return await _context.Price.FirstOrDefaultAsync(x => x.PricaID == id + 1);
        }
    }
}
