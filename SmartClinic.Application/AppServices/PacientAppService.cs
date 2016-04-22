using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.AppServices
{
    public class PacientAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public PacientAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        #endregion

        #region Services

        public Pacient InsertPacient(string name, string dddPhone, string phoneNumber, string rg, 
            string publicPlace, string complement, string number, string neighborhood, string city, Uf addressUf, Sex sex, Guid covenantID)
        {
            using (_unitOfWork)
            {
                var covenant = _unitOfWork.CovenantRepository.Get(covenantID);
                var pacientRg = rg == null ? null : new Rg(rg);
                var address = new Address(publicPlace, complement, number, neighborhood, city, addressUf);
                var phone = Phone.CreatePhone(dddPhone, phoneNumber);

                var pacient = new Pacient(name, address, phone, pacientRg, sex, covenant);
                _unitOfWork.PacientRepository.Add(pacient);

                //Cria a ficha médica do pacient ao criar o mesmo
                var pacientMedicalRecord = new MedicalRecord(pacient, "", "", "", "", "");
                _unitOfWork.MedicalRecordRepository.Add(pacientMedicalRecord);

                _unitOfWork.Commit();
                return pacient;
            }
        }

        public void EditPacientPersonalInfo(Pacient pacient)
        {
            using (_unitOfWork)
            {
                _unitOfWork.PacientRepository.SaveOrAdd(pacient);
                _unitOfWork.Commit();
            }
        }

        public void EditPacientMedicalRecord(MedicalRecord medicalRecord)
        {
            using (_unitOfWork)
            {
                _unitOfWork.MedicalRecordRepository.SaveOrAdd(medicalRecord);
                _unitOfWork.Commit();
            }
        }

        public Pacient SearchPacient(Guid pacientID)
        {
            using (_unitOfWork)
            {
                return _unitOfWork.PacientRepository.Get(pacientID);
            }
        }

        public List<Pacient> SearchPacient(string name)
        {
            using (_unitOfWork)
            {
                return _unitOfWork.PacientRepository.GetPacientsByName(name).ToList();
            }
        }

        public MedicalRecord SearchPacientMedicalRecord(Guid pacientID)
        {
            using (_unitOfWork)
            {
                return _unitOfWork.MedicalRecordRepository.Find(mr => mr.PacientId == pacientID)
                .FirstOrDefault();
            }
        }

        public MedicalRecord SearchPacientMedicalRecord(Pacient pacient)
        {
            //Não é necessário utilizar o using(_unitOfWork) pois chama um método que já o faz.
            return SearchPacientMedicalRecord(pacient.Id);
        }

        #endregion

    }
}
