using AutoMapper;
using RealEstate.Server.Interface;
using RealEstate.Server.Model.PropertyDetails;
using RealEstate.Shared.DTO.PropertyDetails;

namespace RealEstate.Server.Service
{
    public class PropertyService
    {
        private readonly IProperty _propertyRepo;
        private readonly IMapper _mapper;
        public PropertyService(IProperty propertyRepo,IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }
        public IEnumerable<PropertyDTO> GetAllProperty()
        {
            var properties = _propertyRepo.GetAllProperty(); 
            return _mapper.Map<IEnumerable<PropertyDTO>>(properties);
        }
        public PropertyDTO GetPropertyById(int id)
        {
            var properties = _propertyRepo.GetPropertyById(id);
            return _mapper.Map<PropertyDTO>(properties);
        }
        public async Task<bool> AddProperty(PropertyDTO propertyDTO)
        {
            var property = _mapper.Map<Property>(propertyDTO);
            return await _propertyRepo.AddProperty(property);
        }

        public async Task<bool> UpdateProperty(PropertyDTO propertyDTO)
        {
            var existingProperty = _propertyRepo.GetPropertyById(propertyDTO.Id);
            if (existingProperty != null) {

                _mapper.Map(propertyDTO, existingProperty);
                return await _propertyRepo.UpdateProperty(existingProperty);
            }
                
            return false;
        }
    }
}
