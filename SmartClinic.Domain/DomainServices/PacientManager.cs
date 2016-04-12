using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Domain.DomainServices
{
    public class PacientManager : IPacientManager
    {
        #region Prodperties

        private readonly IPacientRepository _pacientRepository;

        #endregion

        #region Constructor

        public PacientManager(IPacientRepository pacientRepository)
        {
            _pacientRepository = pacientRepository;
        }

        #endregion

        #region Services

        public Pacient SetPacientCovenant(Pacient pacient, Covenant covenant)
        {
            //Verifica se o convenio sendo atribuido ao paciente está ativo
            if (!covenant.IsActive())
                throw new InvalidOperationException("O convenio associado ao paciente não está nas condições validas");

            pacient.SetCovenant(covenant);
            return pacient;
        }

        #endregion
    }
}