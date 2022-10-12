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
using SendGrid.Helpers.Mail;

namespace CRUDInventoryQuick.Controllers
{
    public class PrecioController : Controller
    {
        private readonly IRepository<PRECIO>_repository;
        private readonly IRepository<PRODUCTO> _productosRepository;
        private List<SelectListItem> _productos;

        public PrecioController(IRepository<PRECIO> repository, IRepository<PRODUCTO> productosRepository)
        {
            _repository = repository;
            _productosRepository = productosRepository;
        }

        // GET: Precio
        public async Task<IActionResult> Index()
        {
            return _repository.GetAll() != null ?
                        View(await _repository.GetAll()) :
                        Problem("Entity set 'ApplicationDbContext.PRECIOs'  is null.");
        }




        // GET: Precio/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pRECIO = await _repository.GetById(id);
            if (pRECIO == null)
            {
                return NotFound();
            }

            return View(pRECIO);
        }

        // GET: Precio/Create
        public async Task<IActionResult> Create()
        {
           var products = await _productosRepository.GetAll();
            _productos = new List<SelectListItem>();
            foreach (var product in products)
            {
                _productos.Add(new SelectListItem
                {
                    Text = product.Nombre,
                    Value = product.ProductoId.ToString()
                });
            }
            ViewBag.productos = _productos;

            return View();
        }

        // POST: Precio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrecioId,FechaIngreso,PrecioCompra,Descuento,PrecioVentaInicial,PrecioVentaFinal,PRODUCTO_ProductoId")]PRECIO pRECIO)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(pRECIO);
                await _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            var products = await _productosRepository.GetAll();
            _productos = new List<SelectListItem>();
            foreach (var product in products)
            {
                _productos.Add(new SelectListItem
                {
                    Text = product.Nombre,
                    Value = product.ProductoId.ToString()
                });
            }
            ViewBag.productos = _productos;

            return View(pRECIO);
        }

        // GET: Precio/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pRECIO = await _repository.GetById(id);
            if (pRECIO == null)
            {
                return NotFound();
            }
            var products = await _productosRepository.GetAll();
            _productos = new List<SelectListItem>();
            foreach (var product in products)
            {
                _productos.Add(new SelectListItem
                {
                    Text = product.Nombre,
                    Value = product.ProductoId.ToString()
                });
            }
            ViewBag.productos = _productos;
            return View(pRECIO);
        }

        // POST: Precio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrecioId,FechaIngreso,PrecioCompra,Descuento,PrecioVentaInicial,PrecioVentaFinal,PRODUCTO_ProductoId")] PRECIO pRECIO)
        {
            if (id != pRECIO.PrecioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _repository.Update(pRECIO);
                if (result <= 0)
                {

                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(pRECIO);
                }
                var products = await _productosRepository.GetAll();
                _productos = new List<SelectListItem>();
                foreach (var product in products)
                {
                    _productos.Add(new SelectListItem
                    {
                        Text = product.Nombre,
                        Value = product.ProductoId.ToString()
                    });
                }
                ViewBag.productos = _productos;
                return RedirectToAction(nameof(Index));
            }
            return View(pRECIO);
        }

        //GET: Precio/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var pRECIO = await _repository.GetById(id);
            if (pRECIO == null)
            {
                return NotFound();
            }

            return View(pRECIO);
        }

        // POST: Precio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PRECIOs'  is null.");
            }
            var pRECIO = await _repository.GetById(id);
            if (pRECIO != null)
            {
                await _repository.Delete(pRECIO);
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
