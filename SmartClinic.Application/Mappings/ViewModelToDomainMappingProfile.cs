using AutoMapper;
using SmartClinic.Application.AppModels.Doctor;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.Mappings
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Configuração para mapeamento de DTOs para entidades de Dominio
        /// </summary>
        protected override void Configure()
        {
            #region DoctorMappings

             CreateMap<DoctorModel, Doctor>().ConstructUsing(x =>
                new Doctor(x.Name, Rg.CreateRg(x.RgCode), Crm.CreateCrm(x.CrmCode, x.CrmUf), x.Active, x.Sex,
                    Address.CreateAddress(x.PublicPlace, x.Complement, x.Number, x.Neighborhood, x.City, x.Uf)));

            #endregion
        }
    }
}