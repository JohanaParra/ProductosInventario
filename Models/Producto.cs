using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosInventario.Models
{
    public class Producto
    {
        [Required]
        [Display(Name = "Producto")]
        public int idproducto { set; get; }

        [Required]
        [Display(Name = "Categoría")]
        public int idcategoria { set; get; }

        [Required]
        [Display(Name = "Nombre de categoría")]
        public string NombreCat { set; get; }

        [Required]
        [Display(Name = "Código")]
        public string codigo { set; get; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { set; get; }

        [Required]
        [Display(Name = "Precio de Venta")]
        public decimal precio_venta { set; get; }

        [Required]
        [Display(Name = "Stock")]
        public int stock { set; get; }

        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { set; get; }

        [Required]
        [Display(Name = "Imagen")]
        public string imagen { set; get; }

        [Required]
        [Display(Name = "Estado")]
        public bool estado { set; get; }
    }
}
