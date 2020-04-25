using DataAccessLayer;
using Domain;
using Logics.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}
