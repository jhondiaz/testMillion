using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.Entities.POCOs;

namespace TestMillion.Entities.Interfaces
{
    public interface IOwnerRepository
    {
        Task CreateOwner(Owner owner);
        Task<Owner> GetOwner(int id);

        Task<IEnumerable<Owner>> GetOwnersAsync();
    }

}


