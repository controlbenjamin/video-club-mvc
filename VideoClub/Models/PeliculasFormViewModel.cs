using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoClub.Entities;

namespace VideoClub.Models
{
    public class PeliculasFormViewModel
    {

        public Pelicula Pelicula { get; set; }

        public IEnumerable<Genero> Generos { get; set; }


        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        public DateTime? FechaLanzamiento { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        [Required]
        [Range(1, 20)]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género")]
        public int? GeneroId { get; set; }



        public string Titulo
        {
            get
            {
                return (Id != 0) ? "Editar Pelicula" : "Nueva Pelicula";

            }
        }
    }
}