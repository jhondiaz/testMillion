using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.Entities.POCOs;

namespace TestMillion.Entities.Interfaces
{
    public interface IPropertyImageRepository
    {
        void AddImageProperty(PropertyImage propertyImage);
        Task<IEnumerable<PropertyImage>> GetImageProperties(int propertyId);
    }

}


