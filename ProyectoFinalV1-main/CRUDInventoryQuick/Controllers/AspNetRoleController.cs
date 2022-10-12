using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using Microsoft.AspNetCore.Identity;
using CRUDInventoryQuick.Contracts;
using NuGet.Protocol.Core.Types;

namespace CRUDInventoryQuick.Controllers
{
    public class AspNetRoleController : Controller
    {
        private readonly IRepository<ASPNETUSERROLE> _Rolrepository;
        public AspNetRoleController(IRepository<ASPNETUSERROLE> Rolrepository)
        {
            _Rolrepository = Rolrepository;
            
        }

        // GET: AspNetRole
        public async Task<IActionResult> Index()
        {
            return _Rolrepository.GetAll() != null ?
                        View(await _Rolrepository.GetAll()) :
                        Problem("Entity set 'ApplicationDbContext.ASPNETUSERROLEs'  is null.");
        }

        // GET: AspNetRole/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _Rolrepository.GetAll() == null)
            {
                return NotFound();
            }

            var aSPNETUSERROLE = await _Rolrepository.GetById(id);
            if (aSPNETUSERROLE == null)
            {
                return NotFound();
            }

            return View(aSPNETUSERROLE);
        }

        //// GET: AspNetRole/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: AspNetRole/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AspNetRoleId,Nombre")] ASPNETUSERROLE aSPNETUSERROLE)
        {
            if (ModelState.IsValid)
            {
                await _Rolrepository.Add(aSPNETUSERROLE);
                await _Rolrepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(aSPNETUSERROLE);
        }

        // GET: AspNetRole/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            if (id == null || _Rolrepository.GetAll() == null)
            {
                return NotFound();
            }

            var aSPNETUSERROLE = await _Rolrepository.GetById(id);
            if (aSPNETUSERROLE == null)
            {
                return NotFound();
            }
            return View(aSPNETUSERROLE);
        }

        // POST: AspNetRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AspNetRoleId,Nombre")] ASPNETUSERROLE aSPNETUSERROLE)
        {
            if (id != aSPNETUSERROLE.AspNetRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _Rolrepository.Update(aSPNETUSERROLE);
                if (result <= 0)
                {

                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(aSPNETUSERROLE);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(aSPNETUSERROLE);
        }

        //// GET: AspNetRole/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _Rolrepository.GetAll() == null)
            {
                return NotFound();
            }

            var aSPNETUSERROLE = await _Rolrepository.GetById(id);
            if (aSPNETUSERROLE == null)
            {
                return NotFound();
            }

            return View(aSPNETUSERROLE);
        }

        // POST: AspNetRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_Rolrepository.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ASPNETUSERROLEs'  is null.");
            }
            var aSPNETUSERROLE = await _Rolrepository.GetById(id);
            if (aSPNETUSERROLE != null)
            {
                await _Rolrepository.Delete(aSPNETUSERROLE);
            }

            await _Rolrepository.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool ASPNETUSERROLEExists(int id)
        //{
        //  return (_context.ASPNETUSERROLEs?.Any(e => e.AspNetRoleId == id)).GetValueOrDefault();
        //}
    }
}
