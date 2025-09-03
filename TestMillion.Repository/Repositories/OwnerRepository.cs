using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DataContexts;
using TestMillion.Entities.Interfaces;
using TestMillion.Entities.POCOs;


namespace TestMillion.Repository.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly TestMillionContext _context;
        public OwnerRepository(TestMillionContext context) =>
            _context = context;
        public async Task CreateOwner(Owner owner)
        {
            await _context.AddAsync(owner);
        }

        public async Task<Owner> GetOwner(int id)
        {
            var owner = await _context.Owner.FindAsync(id);
            return owner;
        }

        public async Task<IEnumerable<Owner>> GetOwnersAsync()
        {
            var owner = await _context.Owner.ToListAsync();
            return owner;
        }
    }
}
