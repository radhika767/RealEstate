using Microsoft.EntityFrameworkCore;
using RealEstate.Server.Data;
using RealEstate.Server.Interface;
using RealEstate.Server.Model.PropertyDetails;

namespace RealEstate.Server.Repository
{
    public class PropertyRepo : IProperty
    {
        private readonly ApplicationDBContext _context;
        public PropertyRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetAllProperty()
        {
            return _context.Property.ToList();
        }

        public Property GetPropertyById(int id)
        {
            return _context.Property.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> AddProperty(Property property)
        {
            _context.Property.Add(property);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateProperty(Property property)
        {
            _context.Entry(property).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
