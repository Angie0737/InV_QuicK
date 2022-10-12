using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;

namespace CRUDInventoryQuick.Repositorio
{
    public class MarcaRepository : IRepository<MARCA>
    {
        private readonly ApplicationDbContext _context;
        

        public MarcaRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<MARCA>> GetAll()
        {
            return _context.MARCAs.ToList();
        }

        public async Task<MARCA> GetById(int id)
        {
            return _context.MARCAs.SingleOrDefault(m => m.MarcaId.Equals(id));
        }

        public Task Add(MARCA mARCA)
        {
            _context.AddAsync(mARCA);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(MARCA mARCA)
        {
            _context.Remove(mARCA);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<int> Update(MARCA? mARCA)
        {
            _context.Update(mARCA);
            return await _context.SaveChangesAsync();

        }

        public Task Save()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

    }
}
