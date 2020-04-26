using DataAccessLayer;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeedData
{
    public class Seed
    {
        public static void SeedPrice(PriceContext context)
        {
            if (!context.Price.Any())
            {
                var priceData = System.IO.File.ReadAllText("../SeedData/Data/PriceSeedJson.json");
                var price = JsonConvert.DeserializeObject<List<Prica>>(priceData);
                foreach (var prica in price)
                {
                    context.Price.Add(prica);
                }
                context.SaveChanges();
            }
        }

        public static void SeedQuestions(PriceContext context)
        {
            if (!context.Pitanja.Any())
            {
                var pitanjaData = System.IO.File.ReadAllText("../SeedData/Data/PitanjaSeedJson.json");
                var pitanja = JsonConvert.DeserializeObject<List<Pitanje>>(pitanjaData);
                foreach (var prica in pitanja)
                {
                    context.Pitanja.Add(prica);
                }
                context.SaveChanges();
            }
        }
    }
}
