﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoClub.Entities
{

    [Table("Peliculas")]
    public class Pelicula
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaLanzamiento { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }

        [Required]
        public int CantidadDisponible { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }


    }
}