using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Entities;

namespace VideoClub.DTOs
{
    public class NuevoAlquilerDto
    {
        public int ClienteId { get; set; }

        public List<int> PeliculasIds { get; set; }

    }
}