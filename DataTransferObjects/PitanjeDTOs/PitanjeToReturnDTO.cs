using DataTransferObjects.OdgovorDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.PitanjeDTOs
{
    public class PitanjeToReturnDTO
    {
        public int PitanjeID { get; set; }
        public OdgovorDTO Odgovor { get; set; }
    }
}
