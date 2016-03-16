using System;
using AutoMapper;
using SmartClinic.Application.ViewModels.DoctorModels;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ApplicationMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region DoctorMappings

            Mapper.CreateMap<Doctor, RegisterDoctorViewModel>()
                .BeforeMap((doctor, model) =>
                {
                    model.Name = doctor.Name;
                    model.Rg = doctor.Rg.GetFormatedRg();
                    model.CrmCode = Convert.ToString(doctor.Crm.Code);
                    model.CrmUf = doctor.Crm.Uf;
                    model.Address = doctor.Address;
                    model.Active = doctor.Active;
                    model.Sex = doctor.Sex;
                }).ForMember(dest => dest.Rg,
                            opts => opts.MapFrom(src => src.Rg.Code));

            #endregion
        }
    }
}