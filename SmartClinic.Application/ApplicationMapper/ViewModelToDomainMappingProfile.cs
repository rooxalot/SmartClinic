using AutoMapper;
using SmartClinic.Application.ViewModels.UserModels;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.ApplicationMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region UserMappings

            //RegisterUser
            Mapper.CreateMap<RegisterUserViewModel, User>()
                .ConstructUsing(x => new User(x.Login, x.Password, x.Active, x.UserType));

            Mapper.CreateMap<ChangeUserInformationViewModel, User>()
                .ConstructUsing(x => new User(x.Login, x.Password, x.Active, x.UserType));

            #endregion

            #region DoctorMappings

            #endregion
        }
    }
}