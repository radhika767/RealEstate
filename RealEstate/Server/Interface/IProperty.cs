using RealEstate.Server.Model.PropertyDetails;

namespace RealEstate.Server.Interface
{
    public interface IProperty
    {
        IEnumerable<Property> GetAllProperty();
        Task<bool> AddProperty(Property property);
        Task<bool> UpdateProperty(Property property);
        Property GetPropertyById(int id);
    }
}
