using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;

namespace CRUDInventoryQuick.Repositorio
{
    public class CategoriaRepository : IRepository<CATEGORIum>
    {
        private readonly ApplicationDbContext _context;
      

        public CategoriaRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<CATEGORIum>> GetAll()
        {
            return _context.CATEGORIAs.ToList();
        }

        public async Task<CATEGORIum> GetById(int id)
        {
            return _context.CATEGORIAs.SingleOrDefault(c => c.CategoriaId.Equals(id));
        }

        public  Task Add(CATEGORIum categorIum)
        {
            _context.AddAsync(categorIum);
            _context.SaveChanges();
            return Task.CompletedTask;

        }

        public Task Delete(CATEGORIum cATEGORIum)
        {
            _context.Remove(cATEGORIum);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<int> Update(CATEGORIum cATEGORIum)
        {
             _context.Update(cATEGORIum);
           return await _context.SaveChangesAsync();
            
        }

        public Task Save()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }


    }
}
