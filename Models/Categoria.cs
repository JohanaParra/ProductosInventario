using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductosInventario.Models
{
    public class Categoria
    {
        [Required]
        [Display(Name = "Categoría")]
        public int idcategoria { set; get; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { set; get; }

        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { set; get; }

        [Required]
        [Display(Name = "Estado")]
        public bool estado { set; get; }

    }
}
