using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using CRUDInventoryQuick.Contracts;
using NuGet.Protocol.Core.Types;
using SendGrid.Helpers.Mail;
using CRUDInventoryQuick.Repositorio;

namespace CRUDInventoryQuick.Controllers
{
    public class SubcategoriaController : Controller
    {
        private readonly IRepository<SUBCATEGORIum> _Subcategoriarepository;
        private readonly IRepository<CATEGORIum> _CategoriaRepository;
        private List<SelectListItem> _Categoria;

        public SubcategoriaController(IRepository<SUBCATEGORIum> Subcategoriarepository, IRepository<CATEGORIum> CategoriaRepository)
        {
            _Subcategoriarepository = Subcategoriarepository;
            _CategoriaRepository = CategoriaRepository;
        }

        // GET: Subcategoria
        public async Task<IActionResult> Index()
        {

            return _Subcategoriarepository.GetAll() != null ?
            View(await _Subcategoriarepository.GetAll()) :
            Problem("Entity set 'ApplicationDbContext.SUBCATEGORIAs'  is null.");
        }

        // GET: Subcategoria/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _Subcategoriarepository.GetAll() == null)
            {
                return NotFound();
            }

            var sUBCATEGORIum = await _Subcategoriarepository.GetById(id);
            if (sUBCATEGORIum == null)
            {
                return NotFound();
            }

            return View(sUBCATEGORIum);
        }

        // GET: Subcategoria/Create
        public async Task<IActionResult> Create()
        {
            var Categoria = await _CategoriaRepository.GetAll();
            _Categoria = new List<SelectListItem>();
            foreach (var sub in Categoria)
            {
                _Categoria.Add(new SelectListItem
                {
                    Text = sub.Nombre,
                    Value = sub.CategoriaId.ToString()
                });
            }
            ViewBag.categorias = _Categoria;

            return View();
        }

        // POST: Subcategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubcategoriaId,Nombre,Estado,CATEGORIA_CategoriaId")] SUBCATEGORIum sUBCATEGORIum)
        {
            if (ModelState.IsValid)
            {
                await _Subcategoriarepository.Add(sUBCATEGORIum);
                await _Subcategoriarepository.Save();
                return RedirectToAction(nameof(Index));
            }
            var Categoria = await _CategoriaRepository.GetAll();
            _Categoria = new List<SelectListItem>();
            foreach (var sub in Categoria)
            {
                _Categoria.Add(new SelectListItem
                {
                    Text = sub.Nombre,
                    Value = sub.CategoriaId.ToString()
                });
            }
            ViewBag.categorias = _Categoria;
            return View(sUBCATEGORIum);
        }

        // GET: Subcategoria/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _Subcategoriarepository.GetAll() == null)
            {
                return NotFound();
            }

            var sUBCATEGORIum = await _Subcategoriarepository.GetById(id);
            if (sUBCATEGORIum == null)
            {
                return NotFound();
            }
            var Categoria = await _CategoriaRepository.GetAll();
            _Categoria = new List<SelectListItem>();
            foreach (var sub in Categoria)
            {
                _Categoria.Add(new SelectListItem
                {
                    Text = sub.Nombre,
                    Value = sub.CategoriaId.ToString()
                });
            }
            ViewBag.categorias = _Categoria;
            return View(sUBCATEGORIum);
        }

        // POST: Subcategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubcategoriaId,Nombre,Estado,CATEGORIA_CategoriaId")] SUBCATEGORIum sUBCATEGORIum)
        {
            if (id != sUBCATEGORIum.SubcategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _Subcategoriarepository.Update(sUBCATEGORIum);
                if (result <= 0)
                {

                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(sUBCATEGORIum);
                }
                var Categoria = await _CategoriaRepository.GetAll();
                _Categoria = new List<SelectListItem>();
                foreach (var sub in Categoria)
                {
                    _Categoria.Add(new SelectListItem
                    {
                        Text = sub.Nombre,
                        Value = sub.CategoriaId.ToString()
                    });
                }
                ViewBag.categorias = _Categoria;
                return RedirectToAction(nameof(Index));
            }
            return View(sUBCATEGORIum);
        }

        // GET: Subcategoria/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _Subcategoriarepository.GetAll() == null)
            {
                return NotFound();
            }

            var sUBCATEGORIum = await _Subcategoriarepository.GetById(id);
            if (sUBCATEGORIum == null)
            {
                return NotFound();
            }

            return View(sUBCATEGORIum);
        }

        // POST: Subcategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_Subcategoriarepository.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SUBCATEGORIAs'  is null.");
            }
            var sUBCATEGORIum = await _Subcategoriarepository.GetById(id);
            if (sUBCATEGORIum != null)
            {
                await _Subcategoriarepository.Delete(sUBCATEGORIum);
            }
            
            await _Subcategoriarepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
