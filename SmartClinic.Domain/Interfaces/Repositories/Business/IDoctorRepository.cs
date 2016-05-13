
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace SmartClinic.Domain.Interfaces.Repositories.Business
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        IEnumerable<Doctor> GetActiveDoctors();
    }
}