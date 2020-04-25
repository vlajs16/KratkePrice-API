using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataTransferObjects.KorisnikDTOs
{
    public class KorisnikToRegisterDTO
    {
        [Required]
        public string ImePrezime { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
    }
}
