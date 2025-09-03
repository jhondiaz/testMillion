using System.Threading.Tasks;

namespace TestMillion.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }

}


