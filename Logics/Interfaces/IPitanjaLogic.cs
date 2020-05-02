using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Interfaces
{
    public interface IPitanjaLogic
    {
        Task<List<Pitanje>> GetObjects();
        Task<double> SavePoints(List<Pitanje> pitanja, int korisnikID);
        Task<List<Pitanje>> GetPitanjaWithTrueAnswer();
    }
}
