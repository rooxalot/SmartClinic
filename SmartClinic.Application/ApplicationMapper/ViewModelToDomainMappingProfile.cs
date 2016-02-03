using AutoMapper;
using SmartClinic.Application.ViewModels.UserModels;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.ApplicationMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            //User
            Mapper.CreateMap<RegisterUserViewModel, User>();

        }
    }
}