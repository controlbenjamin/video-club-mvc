using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoClub.Validaciones;

namespace VideoClub.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public bool EstaSuscritoNoticias { get; set; }

        

      
        public int TipoMembresiaId { get; set; }


    
      //  [ValidacionMayorEdad18]
        public DateTime? FechaNacimiento { get; set; }
    }
}