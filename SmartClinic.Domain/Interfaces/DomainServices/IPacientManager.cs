using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Domain.Interfaces.DomainServices
{
    public interface IPacientManager
    {
        Pacient SetPacientCovenant(Pacient pacient, Covenant covenant);
    }
}