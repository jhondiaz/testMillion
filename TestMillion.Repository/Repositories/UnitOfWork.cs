using System.Threading.Tasks;
using TestMillion.DataContexts;
using TestMillion.Entities.Interfaces;


namespace TestMillion.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestMillionContext _context;
        public UnitOfWork(TestMillionContext context) =>
            _context = context;
        public Task<int> SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
