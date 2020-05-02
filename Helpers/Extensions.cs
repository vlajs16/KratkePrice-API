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

        public static Odgovor ConvertToOdgovor(this List<Odgovor> odgovori)
        {
            return odgovori[0];
        }

        public static List<Pitanje> ConvertToOdg(this List<Pitanje> pitanja)
        {
            List<Pitanje> nova = new List<Pitanje>();
            foreach (var pitanje in pitanja)
            {
                foreach (var odgovor in pitanje.Odgovori)
                {
                    if (odgovor.Tacan)
                    {
                        nova.Add(new Pitanje
                        {
                            PitanjeID = pitanje.PitanjeID,
                            Vrednost = pitanje.Vrednost,
                            Odgovori = new List<Odgovor>
                            {
                                new Odgovor
                                {
                                    OdgovorID = odgovor.OdgovorID,
                                    Vrednost = odgovor.Vrednost,
                                    Tacan = odgovor.Tacan
                                }
                            }
                        });
                    }
                }
            }
            return nova;
        }
    }
}
