using AutoMapper;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.MVC.ViewModels;

namespace SmartClinic.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Appointment, AppointmentViewModel>();
            Mapper.CreateMap<Clinic, ClinicViewModel>();
            Mapper.CreateMap<Covenant, CovenantViewModel>();
            Mapper.CreateMap<Doctor, DoctorViewModel>();
            Mapper.CreateMap<MedicalRecord, MedicalRecordViewModel>();
            Mapper.CreateMap<Pacient, PacientViewModel>();
            Mapper.CreateMap<Secretary, SecretaryViewModel>();
            Mapper.CreateMap<User, UserViewModel>();
        }
    }
}