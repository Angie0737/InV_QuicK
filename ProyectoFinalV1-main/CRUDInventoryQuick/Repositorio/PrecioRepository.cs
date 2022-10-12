using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;

namespace CRUDInventoryQuick.Repositorio
{
    public class PrecioRepository : IRepository<PRECIO>
    {
        private readonly ApplicationDbContext _context;
        

        public PrecioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PRECIO>> GetAll()
        {
            var applicationDbContext = _context.PRECIOs.Include(p => p.Producto);
            return applicationDbContext.ToList();
        }

        public async Task<PRECIO> GetById(int id)
        {
            return _context.PRECIOs.Include(p => p.Producto).SingleOrDefault(c => c.PrecioId.Equals(id));
        }

        public Task Add(PRECIO pRECIO)
        {
            _context.AddAsync(pRECIO);
            _context.SaveChanges();
            return Task.CompletedTask;

        }

        public Task Delete(PRECIO pRECIO)
        {
            _context.Remove(pRECIO);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<int> Update(PRECIO pRECIO)
        {
            _context.Update(pRECIO);
            return await _context.SaveChangesAsync();

        }

        public Task Save()
        {
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        //Cambios git (eliminar)
    }
}

