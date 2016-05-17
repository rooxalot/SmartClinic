using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using System.Configuration;

namespace SmartClinic.Application.AppServices
{
    public class ClinicAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ClinicAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region AppServices


        /// <summary>
        /// Verifica se a clinica registrada já se encontra na sessão, caso não, adiciona a mesma
        /// </summary>
        public void RegisterClinic()
        {
            var clinic = SessionManager.Clinic;

            //Caso o objeto na sessão esteja vazio, obtem o ID do mesmo nas configurações e após recupera-lo no banco, guarda na sessão
            if (clinic == null)
            {
                var ID = ConfigurationManager.AppSettings["RegisteredClinic"];
                var clinicID = Guid.Parse(ID);

                using (_unitOfWork) { clinic = _unitOfWork.ClinicRepository.Get(clinicID); }
                SessionManager.Clinic = clinic;
            }
        }

        public void CreateClinicRecord(string name, string header, string cnpjCode, string phoneNumber, string dddNumber)
        {
            var cnpj = new Cnpj(cnpjCode);
            var phone = Phone.CreatePhone(dddNumber, phoneNumber);

            var clinic = new Clinic(name, header, cnpj, phone);

            using (_unitOfWork)
            {
                _unitOfWork.ClinicRepository.Add(clinic);
                _unitOfWork.Commit();
            }
        }

        public void EditClinicHeader(Guid clinicID, string header)
        {
            using (_unitOfWork)
            {
                var clinic = _unitOfWork.ClinicRepository.Get(clinicID);
                clinic.SetHeader(header);

                _unitOfWork.ClinicRepository.SaveOrAdd(clinic);
                _unitOfWork.Commit();
            }
        }

        #endregion
    }
}
