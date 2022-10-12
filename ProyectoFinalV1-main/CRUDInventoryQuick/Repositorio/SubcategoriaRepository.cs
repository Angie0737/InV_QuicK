using CRUDInventoryQuick.Contracts;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDInventoryQuick.Repositorio
{

        public class SubcategoriaRepository : IRepository<SUBCATEGORIum>
        {
            private readonly ApplicationDbContext _context;


            public SubcategoriaRepository(ApplicationDbContext context)
            {
                this._context = context;
            }

            public async Task<IEnumerable<SUBCATEGORIum>> GetAll()
            {
                var applicationDbContext = _context.SUBCATEGORIAs.Include(s => s.Categoria);
                return applicationDbContext.ToList();
            }

            public async Task<SUBCATEGORIum> GetById(int id)
            {
                return _context.SUBCATEGORIAs
                 .Include(s => s.Categoria)
                 .FirstOrDefault(m => m.SubcategoriaId == id);
            }

            public Task Add(SUBCATEGORIum sUBCATEGOR)
            {
                _context.AddAsync(sUBCATEGOR);
                _context.SaveChanges();
                return Task.CompletedTask;

            }

            public Task Delete(SUBCATEGORIum sUBCATEGOR)
            {
                _context.Remove(sUBCATEGOR);
                _context.SaveChanges();
                return Task.CompletedTask;
            }

            public async Task<int> Update(SUBCATEGORIum sUBCATEGOR)
            {
                _context.Update(sUBCATEGOR);
                return await _context.SaveChangesAsync();

            }

            public Task Save()
            {
                _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
        }
    
}
