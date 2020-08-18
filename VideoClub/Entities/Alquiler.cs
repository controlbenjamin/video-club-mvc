using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoClub.Entities
{
    [Table("Alquileres")]
    public class Alquiler
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        public Pelicula Pelicula { get; set; }

        public int PeliculaId { get; set; }

        public DateTime FechaAlquiler { get; set; }


        public DateTime? FechaDevolucion { get; set; }

    }
}