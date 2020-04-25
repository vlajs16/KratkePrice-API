using System;

namespace Domain
{
    public class Korisnik
    {
        public int KorisnikID { get; set; }
        public string ImePrezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumUcesca { get; set; }
        public double Poeni { get; set; }
    }
}
