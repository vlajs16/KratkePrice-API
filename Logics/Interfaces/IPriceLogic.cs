using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logics.Interfaces
{
    public interface IPriceLogic
    {
        Task<List<Prica>> GetObjects();
        Task<Prica> GetById(int id);
    }
}
