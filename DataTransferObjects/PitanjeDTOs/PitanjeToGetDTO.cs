using DataTransferObjects.OdgovorDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.PitanjeDTOs
{
    public class PitanjeToGetDTO
    {
        public int PitanjeID { get; set; }
        public string Vrednost { get; set; }
        public List<OdgovorDTO> Odgovori { get; set; }
    }
}
