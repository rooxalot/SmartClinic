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
    public class SecretaryAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public SecretaryAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region AppServices

        public Secretary RegisterSecretary(string name, string rg, string dddPhone, string phoneNumber, Sex sex,
            string publicPlace, string complement, string number, string neighborhood, string city, Uf addressUf)
        {
            var secretaryRg = (rg == null ? null : new Rg(rg));
            var address = new Address(publicPlace, complement, number, neighborhood, city, addressUf);
            var phone = Phone.CreatePhone(dddPhone, phoneNumber);

            using (_unitOfWork)
            {
                var secretary = new Secretary(name, secretaryRg, phone, address, sex);
                _unitOfWork.SecretaryRepository.Add(secretary);
                _unitOfWork.Commit();

                return secretary;
            }
        }

        public void EditSecretary(Secretary secretary)
        {
            using (_unitOfWork)
            {
                _unitOfWork.SecretaryRepository.SaveOrAdd(secretary);
                _unitOfWork.Commit();
            }
        }

        public void RemoveSecretary(Guid secretaryID)
        {
            using (_unitOfWork)
            {
                var secretary = _unitOfWork.SecretaryRepository.Get(secretaryID);

                _unitOfWork.SecretaryRepository.Remove(secretary);
                _unitOfWork.Commit();
            }
        }

        #endregion

    }
}
