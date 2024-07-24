using AutoMapper;
using RealEstate.Server.Model.PropertyDetails;
using RealEstate.Shared.DTO.PropertyDetails;

namespace RealEstate.Server.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Property, PropertyDTO>();
            CreateMap<PropertyDTO, Property>();
        }
    }
}
