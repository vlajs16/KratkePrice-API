using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Interfaces
{
    public interface IAuthLogic
    {
        Task<Korisnik> Register(Korisnik korisnik);
        Task<bool> ProveraPostojecih(string email, string telefon, string korisnickoIme);
    }
}
