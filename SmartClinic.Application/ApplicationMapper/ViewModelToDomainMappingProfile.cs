using AutoMapper;
using SmartClinic.Application.ViewModels;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.ApplicationMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AppointmentViewModel, Appointment>();
            Mapper.CreateMap<ClinicViewModel, Clinic>();
            Mapper.CreateMap<CovenantViewModel, Covenant>();
            Mapper.CreateMap<DoctorViewModel, Doctor>();
            Mapper.CreateMap<MedicalRecordViewModel, MedicalRecord>();
            Mapper.CreateMap<PacientViewModel, Pacient>();
            Mapper.CreateMap<SecretaryViewModel, Secretary>();
            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}