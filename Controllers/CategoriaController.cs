using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductosInventario.Controllers
{
    public class CategoriaController : Controller
    {
        /*Llamado...*/
        CategoriaDataAccessLayer categoriaDataAccessLayer = null;
        public CategoriaController()
        {
            categoriaDataAccessLayer = new CategoriaDataAccessLayer();
        }

        // GET: CategoriaController
        public ActionResult Index()
        {
            IEnumerable<Categoria> categorias = categoriaDataAccessLayer.GetAllCategorias();
            return View(categorias);
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            Categoria categoria = categoriaDataAccessLayer.GetCategoriaData(id);
            return View(categoria);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoría)
        {
            try
            {
                categoriaDataAccessLayer.AddCategoria(categoría);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            Categoria categoria = categoriaDataAccessLayer.GetCategoriaData(id);
            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            try
            {
                categoriaDataAccessLayer.UpdateCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Categoria categoria = categoriaDataAccessLayer.GetCategoriaData(id);
            return View(categoria);
        }

        // GET: CategoriaController/Delete/5
        [HttpGet]
        public ActionResult EjecutarDelete(int id)
        {
            try
            {
                categoriaDataAccessLayer.DeleteCategoria(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                return View();
            }
        }
       
    }
}
