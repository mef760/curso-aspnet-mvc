using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCars.Data;
using MvcCars.Models;
using MvcCars.Services;

namespace MvcCars.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMarcaService _marcaService;

        public CarsController(
            ICarService carService,
            IMarcaService marcaService)
        {
            _carService = carService;
            _marcaService = marcaService;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return View(_carService.GetAllCars());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_marcaService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Type,Dominio,Color,MarcaId")] Car car)
        {
            // TODO: implementar viewmodel
            ModelState.Remove("Marca");
            ModelState.Remove("Accesories");
            if (ModelState.IsValid)
            {
                _carService.CreateCar(car);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_marcaService.GetAll(), "Id", "Name", car.MarcaId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_marcaService.GetAll(), "Id", "Id", car.MarcaId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Type,Dominio,Color,MarcaId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carService.UpdateCar(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["MarcaId"] = new SelectList(_marcaService.GetAll(), "Id", "Id", car.MarcaId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = _carService.GetCarById(id);
            if (car != null)
            {
                _carService.DeleteCar(car);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_carService.GetCarById(id) != null);
        }
    }
}
