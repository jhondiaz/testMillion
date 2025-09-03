using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMillion.DataContexts;
using TestMillion.Entities.Interfaces;
using TestMillion.Entities.POCOs;


namespace TestMillion.Repository.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly TestMillionContext _context;
        public PropertyImageRepository(TestMillionContext context) =>
            _context = context;
        public void AddImageProperty(PropertyImage propertyImage)
        {
            _context.Add(propertyImage);
        }

        public async Task<IEnumerable<PropertyImage>> GetImageProperties(int propertyId)
        {
            return await _context.PropertyImage.Where(w => w.PropertyId == propertyId).ToListAsync();
        }
    }
}
