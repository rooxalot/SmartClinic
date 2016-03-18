using System;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Entities.Business
{
    public class Covenant : BaseEntity
    {
        #region Constructor

        //Construtor EntityFramework
        protected Covenant()
        {
        }

        public Covenant(string name, bool active, DateTime startTerm, DateTime endTerm, Phone phone, Cnpj cnpj, string offeredPlans)
        {
            SetName(name);
            Active = active;
            SetPhone(phone);
            SetCnpj(cnpj);
            SetStartAndEndTerm(startTerm, endTerm);
            SetOfferedPlans(offeredPlans);
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public Phone Phone { get; set; }
        public Cnpj Cnpj { get; set; }
        public bool Active { get; set; }
        public DateTime StartTerm { get; private set; }
        public DateTime? EndTerm { get; private set; }
        public string OfferedPlans { get; private set; }

        #endregion

        #region Constants

        public const int NameMinLength = 2;
        public const int NameMaxLength = 150;
        public const int OfferedPlansMaxLength = 500;

        #endregion

        #region Methods

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Nome do convenio não pode ser nulo ou vazio");
            
            if(name.Length < NameMinLength || name.Length > NameMaxLength)
                throw new InvalidOperationException(string.Format("O Nome da clinica deve possuir entre {0} a {1}", NameMinLength, NameMaxLength));

            Name = name;
        }

        public void SetPhone(Phone phone)
        {
            Phone = phone ?? new Phone();
        }

        public void SetCnpj(Cnpj cnpj)
        {
            Cnpj = cnpj ?? new Cnpj();
        }

        public void SetOfferedPlans(string plans)
        {
            if (plans == null)
            {
                OfferedPlans = "";
                return;
            }


            if(plans.Length > OfferedPlansMaxLength)
                throw new InvalidOperationException(string.Format("O Nome da clinica deve possuir no máximo {0} caracteres", OfferedPlansMaxLength));

            OfferedPlans = plans;
        }

        public void SetStartAndEndTerm(DateTime start, DateTime? end)
        {
            // Caso seja colocado como inicio do contrato de convenio uma data maior que o fim, é realizada uma inversão nas datas.
            if (end.HasValue && start > end)
            {
                StartTerm = end.Value;
                EndTerm = start;
            }
            else
            {
                StartTerm = start;
                EndTerm = end;
            }
        }

        public bool IsActive()
        {
            if(!EndTerm.HasValue)
                return (StartTerm.Date <= DateTime.Today && Active);

            return (StartTerm.Date <= DateTime.Today && EndTerm.GetValueOrDefault().Date >= DateTime.Today && Active);
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(Covenant))
                return false;

            var covenantObj = (Covenant) obj;
            return Name == covenantObj.Name && Id == covenantObj.Id;
        }

        #endregion
    }
}