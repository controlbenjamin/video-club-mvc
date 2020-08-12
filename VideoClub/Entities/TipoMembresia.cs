using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoClub.Entities
{
    [Table("TipoMembresia")]
    public class TipoMembresia
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public decimal TarifaRegistro { get; set; }

        public byte DuracionEnMeses { get; set; }

        public byte TasaDescuento { get; set; }

    }
}