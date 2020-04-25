using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.PricaDTOs
{
    public class PricaForDetailsDTO
    {
        public int PricaID { get; set; }
        public string Naziv { get; set; }
        public string VideoUrl { get; set; }
        public string Text { get; set; }
    }
}
