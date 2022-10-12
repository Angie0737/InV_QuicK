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
using CRUDInventoryQuick.Repositorio;

namespace CRUDInventoryQuick.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IRepository<CATEGORIum> _repository;


        //private readonly ApplicationDbContext _repository;

        public CategoriaController(IRepository<CATEGORIum> repository)
        {
            _repository = repository;
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
              return _repository.GetAll() != null ? 
                          View(await _repository.GetAll()) :
                          Problem("Entity set 'ApplicationDbContext.CATEGORIAs'  is null.");
        }




        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cATEGORIum = await _repository.GetById(id);
            if (cATEGORIum == null)
            {
                return NotFound();
            }

            return View(cATEGORIum);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Estado,Nombre")] CATEGORIum cATEGORIum)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(cATEGORIum);
                await _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cATEGORIum);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cATEGORIum = await _repository.GetById(id);
            if (cATEGORIum == null)
            {
                return NotFound();
            }
            return View(cATEGORIum);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Estado,Nombre")] CATEGORIum cATEGORIum)
        {
            if (id != cATEGORIum.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _repository.Update(cATEGORIum);
                if (result <= 0)
                {

                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(cATEGORIum);
                }
               
                return RedirectToAction(nameof(Index));
            }
            return View(cATEGORIum);
        }

        //GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cATEGORIum = await _repository.GetById(id);
            if (cATEGORIum == null)
            {
                return NotFound();
            }

            return View(cATEGORIum);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CATEGORIAs'  is null.");
            }
            var cATEGORIum = await _repository.GetById(id);
            if (cATEGORIum != null)
            {
                  await _repository.Delete(cATEGORIum);
            }

            await _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool CATEGORIumExists(int id)
        //{
        //    return (_repository.GetAll().Any(e => e.CategoriaId == id)).GetValueOrDefault();
        //}
    }
}
