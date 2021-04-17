using CasaPopular.Application.Interface;
using CasaPopular.Application.ViewModels;
using CasaPopular.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CasaPopular.Presentation.Controllers
{
    public class FamiliaController : Controller
    {
        private readonly IFamiliaService _contemplarFamiliaService;

        public FamiliaController(IFamiliaService contemplarFamiliaService)
        {
            _contemplarFamiliaService = contemplarFamiliaService;
        }

        // GET: FamiliaController
        public IActionResult Index()
        {
            var listaFamilias = _contemplarFamiliaService.ObterTodasFamiliasComtemplaveis();

            listaFamilias ??= new List<Familia>();

            return View(listaFamilias);
        }

        // GET: FamiliaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FamiliaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamiliaController/Create
        [HttpPost]
        public ActionResult Create([FromBody] CadastroFamiliaViewModel cadastrar)
        {
            try
            {
                _contemplarFamiliaService.CadastrarFamilia(cadastrar);

                return Json(true);
            }
            catch
            {
                return View();
            }
        }

        // GET: FamiliaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FamiliaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FamiliaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FamiliaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}