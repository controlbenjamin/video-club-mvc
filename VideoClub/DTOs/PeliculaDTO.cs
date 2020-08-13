using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoClub.DTOs
{
    public class PeliculaDTO
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
        public int GeneroId { get; set; }
      
    }
}