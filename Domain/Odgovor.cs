using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Odgovor
    {
        public int PitanjeID { get; set; }
        public int OdgovorID { get; set; }
        public string Vrednost { get; set; }
        public bool Tacan { get; set; }
    }
}
