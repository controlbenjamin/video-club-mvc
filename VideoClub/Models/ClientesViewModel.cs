using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Entities;

namespace VideoClub.Models
{
    public class ClientesViewModel
    {

        public IEnumerable<Cliente> Clientes { get; set; }

        public Cliente Cliente { get; set; }

        public IEnumerable<TipoMembresia> TipoMembresias { get; set; }
    }
}