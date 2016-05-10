using AutoMapper;

namespace SmartClinic.Application.Mappings
{
    public class MappingConfig
    {
        public static void RegisterMappings()
	        {
	            Mapper.Initialize(x =>
	            {
	                x.AddProfile<DomainToViewModelMappingProfile>();
	                x.AddProfile<ViewModelToDomainMappingProfile>();
	            });
	        }
    }
}
