using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCars.Data;
using MvcCars.Models;
using MvcCars.Services;

namespace MvcCars.Controllers
{
    public class MarcasController : Controller
    {
        private readonly IMarcaService _marcaService;

        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        // GET: Marcas
        public async Task<IActionResult> Index(string name)
        {
              var list = _marcaService.GetAll();
              if (!string.IsNullOrEmpty(name))
              {
                list = list.Where(x=> x.Name.ToLower().Contains(name.ToLower()));
              }
              var model = new MarcaViewModel();
              model.Marcas = list.ToList();

              return View(model); 
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marcaService.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Made")] Marca marca)
        {
            // TODO: Implementar un viewModel para usar el modelo que esta en la vista.
            ModelState.Remove("Cars");

            if (ModelState.IsValid)
            {
                _marcaService.Create(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marcaService.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Made")] Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _marcaService.Update(marca);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _marcaService.GetById(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = _marcaService.GetById(id);
            if (marca != null)
            {
                _marcaService.Delete(marca);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
          return _marcaService.GetById(id) != null;
        }
    }
}