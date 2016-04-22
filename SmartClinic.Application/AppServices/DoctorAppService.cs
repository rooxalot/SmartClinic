using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using System;

namespace SmartClinic.Application.AppServices
{
    public class DoctorAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorManager _doctorManager;

        #endregion

        #region Constructor

        public DoctorAppService(IUnitOfWork unitOfWork, IDoctorManager doctorManager)
        {
            _unitOfWork = unitOfWork;
            _doctorManager = doctorManager;
        }

        #endregion

        #region AppServices

        public void RegisterDoctor(string name, string rg, string crmCode, Uf crmUf, bool active, Sex sex,
            string publicPlace, string complement, string number, string neighborhood, string city, Uf addressUf)
        {
            Rg doctorRg = (rg == null ? null : new Rg(rg));
            var doctorCrm = new Crm(crmCode, crmUf);
            var address = new Address(publicPlace, complement, number, neighborhood, city, addressUf);
            var doctor = new Doctor(name, doctorRg, doctorCrm, active, sex, address);

            using (_unitOfWork)
            {
                doctor = _doctorManager.SetDoctorCrm(doctor, doctorCrm);

                _unitOfWork.DoctorRepository.Add(doctor);
                _unitOfWork.Commit();
            }
        }

        public void EditDoctor(Doctor doctor)
        {
            using (_unitOfWork)
            {
                doctor = _doctorManager.SetDoctorCrm(doctor, doctor.Crm);

                _unitOfWork.DoctorRepository.SaveOrAdd(doctor);
                _unitOfWork.Commit();
            }
        }

        public void RemoveDoctor(Guid doctorID)
        {
            using (_unitOfWork)
            {
                var doctor = _unitOfWork.DoctorRepository.Get(doctorID);
                doctor = _doctorManager.DeactivateDoctor(doctor);

                _unitOfWork.DoctorRepository.SaveOrAdd(doctor);
                _unitOfWork.Commit();
            }
        }

        #endregion
    }
}
