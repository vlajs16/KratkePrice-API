using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Pitanje
    {
        public int PitanjeID { get; set; }
        public string Vrednost { get; set; }
        public List<Odgovor> Odgovori { get; set; }
    }
}
