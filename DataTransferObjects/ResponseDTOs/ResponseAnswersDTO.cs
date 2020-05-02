using DataTransferObjects.PitanjeDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.ResponseDTOs
{
    public class ResponseAnswersDTO
    {
        public List<PitanjeToReturnDTO> Pitanja { get; set; }
        public double Poeni { get; set; }
    }
}
