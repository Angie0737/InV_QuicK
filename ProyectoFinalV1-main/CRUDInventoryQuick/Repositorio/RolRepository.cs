using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;

namespace CRUDInventoryQuick.Repositorio
{
    public class RolRepository : IRepository<ASPNETUSERROLE>
    {

        private readonly ApplicationDbContext _context;
        

        public RolRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ASPNETUSERROLE>> GetAll()
        {
            return _context.ASPNETUSERROLEs.ToList();
        }

        public async Task<ASPNETUSERROLE> GetById(int id)
        {
            return _context.ASPNETUSERROLEs.SingleOrDefault(c => c.AspNetRoleId.Equals(id));
        }

        public Task Add(ASPNETUSERROLE aSPNETUSERROLE)
        {
            _context.AddAsync(aSPNETUSERROLE);
            _context.SaveChanges();
            return Task.CompletedTask;

        }

        public Task Delete(ASPNETUSERROLE aSPNETUSERROLE)
        {
            _context.Remove(aSPNETUSERROLE);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<int> Update(ASPNETUSERROLE aSPNETUSERROLE)
        {
            _context.Update(aSPNETUSERROLE);
            return await _context.SaveChangesAsync();

        }

        public Task Save()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

    }
}
