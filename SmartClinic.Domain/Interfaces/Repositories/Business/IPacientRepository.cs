using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Base;

namespace SmartClinic.Domain.Interfaces.Repositories.Business
{
    public interface IPacientRepository : IRepositoryBase<Pacient>
    {
        IEnumerable<Pacient> GetPacientsByName(string name);
    }
}