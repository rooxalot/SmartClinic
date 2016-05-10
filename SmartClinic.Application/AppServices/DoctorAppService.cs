using AutoMapper;
using SmartClinic.Application.AppModels.Doctor;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Obtem uma lista de modelos (DoctorModel)
        /// </summary>
        /// <returns>IEnumerable de DoctorModel</returns>
        public IEnumerable<DoctorModel> GetDoctors()
        {
            using (_unitOfWork)
            {
                var doctors = _unitOfWork.DoctorRepository.GetAll();
                var mappedDoctors = Mapper.Map<IEnumerable<DoctorModel>>(doctors);
                return mappedDoctors;
            }
        }

        /// <summary>
        /// Retorna os dados do médico com o ID informado
        /// </summary>
        /// <param name="id">ID do médico </param>
        /// <returns>DTO com os dados do médico com o ID informado</returns>
        public DoctorModel GetDoctorById(Guid id)
        {
            using (_unitOfWork)
            {
                var doctor = _unitOfWork.DoctorRepository.Get(id);
                var mappedDoctor = Mapper.Map<DoctorModel>(doctor);
                return mappedDoctor;
            }
        }

        public void RegisterDoctor(string name, string rg, string crmCode, Uf crmUf, bool active, Sex sex,
            string publicPlace, string complement, string number, string neighborhood, string city, Uf addressUf)
        {
            var doctorRg = Rg.CreateRg(rg);
            var doctorCrm = Crm.CreateCrm(crmCode, crmUf);
            var address = Address.CreateAddress(publicPlace, complement, number, neighborhood, city, addressUf);
            var doctor = new Doctor(name, doctorRg, doctorCrm, active, sex, address);

            using (_unitOfWork)
            {
                doctor = _doctorManager.SetDoctorCrm(doctor, doctorCrm);

                _unitOfWork.DoctorRepository.Add(doctor);
                _unitOfWork.Commit();
            }
        }

        /// <summary>
        /// Realiza os passos para a edição do Médico
        /// </summary>
        /// <param name="doctorModel">DTO com os dados a serem passados para o Dominio e serem atualizados</param>
        public void EditDoctor(DoctorModel doctorModel)
        {
            using (_unitOfWork)
            {
                //Obtem o médico no banco de dados
                var doctor = _unitOfWork.DoctorRepository.Get(doctorModel.Id);

                //Atualiza os dados do médico após realizar o mapeamento da ViewModel para a entidade de Dominio
                doctor = Mapper.Map(doctorModel, doctor,
                    o => o.AfterMap( (source, destination) => _doctorManager.SetDoctorCrm(destination, Crm.CreateCrm(source.CrmCode, source.CrmUf)) ));

                //Atualiza o médico no Banco de dados
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
