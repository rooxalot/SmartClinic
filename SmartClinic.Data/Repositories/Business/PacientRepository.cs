using System;
using System.Collections.Generic;
using System.Linq;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class PacientRepository : RepositoryBase<Pacient>, IPacientRepository
    {
        public PacientRepository(SmartClinicContext context) 
            : base(context)
        {
        }

        public SmartClinicContext SmartClinicContext => Context as SmartClinicContext;


        public IEnumerable<Pacient> GetPacientsByName(string name)
        {
            return SmartClinicContext.Pacients
                .Where(p => p.Name == name)
                .ToList();
        }
    }
}