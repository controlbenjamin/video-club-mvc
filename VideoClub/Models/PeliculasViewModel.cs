using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Entities;

namespace VideoClub.Models
{
    public class PeliculasViewModel
    {

        public IEnumerable<Pelicula> Peliculas { get; set; }

        public Pelicula Pelicula { get; set; }
    }
}