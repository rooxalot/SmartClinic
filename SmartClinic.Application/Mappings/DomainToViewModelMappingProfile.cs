using AutoMapper;
using SmartClinic.Application.AppModels.Doctor;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.Mappings
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Configuração para mapeamento de entidades de Dominio para DTOs
        /// </summary>
        protected override void Configure()
        {
            #region DoctorMapping

            CreateMap<Doctor, DoctorModel>()
                .ForMember(d => d.CrmCode, o => o.MapFrom(s => s.Crm.Code))
                .ForMember(d => d.CrmUf, o => o.MapFrom(s => s.Crm.Uf))
                .ForMember(d => d.PublicPlace, o => o.MapFrom(s => s.Address.PublicPlace))
                .ForMember(d => d.Complement, o => o.MapFrom(s => s.Address.Complement))
                .ForMember(d => d.Number, o => o.MapFrom(s => s.Address.Number))
                .ForMember(d => d.Neighborhood, o => o.MapFrom(s => s.Address.Neighborhood))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.Uf, o => o.MapFrom(s => s.Address.Uf));

            #endregion
        }
    }
}