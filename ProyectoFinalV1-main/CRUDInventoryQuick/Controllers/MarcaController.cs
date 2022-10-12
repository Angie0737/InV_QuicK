using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDInventoryQuick.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;

namespace CRUDInventoryQuick.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IRepository<MARCA> _repository;
        // private readonly ApplicationDbContext _context;

        public MarcaController(IRepository<MARCA> repository)
        {
            _repository = repository;
        }

        // GET: Marca
        public async Task<IActionResult> Index()
        {
            return _repository.GetAll() != null ?
                        View(await _repository.GetAll()) :
                        Problem("Entity set 'ApplicationDbContext.MARCAs'  is null.");
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _repository.GetById(id) == null)
            {
                return NotFound();
            }

            var mARCA = await _repository.GetById(id);
            if (mARCA == null)
            {
                return NotFound();
            }

            return View(mARCA);
        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarcaId,Nombre,Estado")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(mARCA);
                await _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(mARCA);
        }

        //// GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _repository.GetAll() == null)
            {
                return NotFound();
            }

            var mARCA = await _repository.GetById(id);
            if (mARCA == null)
            {
                return NotFound();
            }
            return View(mARCA);
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarcaId,Nombre,Estado")] MARCA mARCA)
        {
            if (id != mARCA.MarcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _repository.Update(mARCA);
                if (result <= 0)
                {

                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(mARCA);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(mARCA);
        }

        //// GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _repository.GetAll() == null)
            {
                return NotFound();
            }

            var mARCA = await _repository.GetById(id);
            if (mARCA == null)
            {
                return NotFound();
            }

            return View(mARCA);
        }

        //// POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MARCAs'  is null.");
            }
            var mARCA = await _repository.GetById(id);
            if (mARCA != null)
            {
                await _repository.Delete(mARCA);
            }

            await _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
