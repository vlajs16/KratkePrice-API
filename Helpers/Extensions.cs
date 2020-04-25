using DataTransferObjects.OdgovorDTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class Extensions
    {
        public static double CalculatePoints(this List<Pitanje> pitanjaIzBaze, List<Pitanje> pitanjaKorisnika)
        {
            double poeni = 0;
            for (int i = 0; i < pitanjaIzBaze.Count; i++)
            {
                for (int j = 0; j < pitanjaIzBaze[i].Odgovori.Count; j++)
                {
                    if (pitanjaIzBaze[i].Odgovori[j].OdgovorID != pitanjaKorisnika[i].Odgovori[0].OdgovorID)
                        continue;
                    if (pitanjaIzBaze[i].Odgovori[j].Tacan)
                        poeni += 10;
                    else poeni -= 2;
                }
            }
            return (double)(poeni * 100) / (pitanjaIzBaze.Count * 10);
        }

        public static List<OdgovorDTO> ConvertToList(this OdgovorDTO odgovor)
        {
            List<OdgovorDTO> odgovori = new List<OdgovorDTO>();
            odgovori.Add(odgovor);
            return odgovori;
        }
    }
}
