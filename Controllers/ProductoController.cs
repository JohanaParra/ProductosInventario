using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductosInventario.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductosInventario.Controllers
{
    public class ProductoController : Controller
    {

        /*Llamado...*/
        ProductoDataAccessLayer productoDataAccessLayer = null;
        CategoriaDataAccessLayer categoriaDataAccessLayer = null;

        public ProductoController()
        {
            productoDataAccessLayer = new ProductoDataAccessLayer();
            categoriaDataAccessLayer = new CategoriaDataAccessLayer();
        }
      
        // GET: ProductoController
        public ActionResult Index()
        {
            IEnumerable<Producto> productos = productoDataAccessLayer.GetAllProducto();            
            return View(productos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            Producto producto = productoDataAccessLayer.GetProductoData(id);
            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            List<Categoria> lstCategorias = categoriaDataAccessLayer.GetAllCategorias();
            List<SelectListItem> lstCombo = lstCategorias.ConvertAll(x => new SelectListItem() { Value= x.idcategoria.ToString() , Text = x.nombre.ToString() });
            ViewBag.categorias = lstCombo; 
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            try
            {
                productoDataAccessLayer.AddProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception Ex)
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            Producto producto = productoDataAccessLayer.GetProductoData(id);
            List<Categoria> lstCategorias = categoriaDataAccessLayer.GetAllCategorias();
            List<SelectListItem> lstCombo = lstCategorias.ConvertAll(x => new SelectListItem() { Value = x.idcategoria.ToString(), Text = x.nombre.ToString() });
            ViewBag.categorias = lstCombo;
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            try
            {
                productoDataAccessLayer.UpdateProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            Producto producto = productoDataAccessLayer.GetProductoData(id);
            return View(producto);
        }

        // Get: ProductoController/Delete/5
        [HttpGet]
        
        public ActionResult EjecutarDelete(int id)
        {
            try
            {
                productoDataAccessLayer.DeleteProducto(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                return View();
            }
        }
    }
}
