using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using VideoClub.DTOs;
using VideoClub.Entities;

namespace VideoClub.Controllers.Api
{
    public class AlquileresController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AlquileresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CrearNuevoAlquiler([FromBody]NuevoAlquilerDto nuevoAlquilerDto)
        {
            if (nuevoAlquilerDto.PeliculasIds.Count == 0)
            {
                return BadRequest("No se proporcionaron PeliculasId");
            }

            var cliente = _context.Clientes.SingleOrDefault
                (c => c.Id == nuevoAlquilerDto.ClienteId);

            if (cliente == null)
            {
                return BadRequest("ClienteId Inválido");
            }



            var peliculas = _context.Peliculas.Where(p =>
                            nuevoAlquilerDto.PeliculasIds.Contains(p.Id)).ToList();


            if (peliculas.Count != nuevoAlquilerDto.PeliculasIds.Count)
            {
                return BadRequest("Una o más PeliculasId son invalidas");
            }


            foreach (var pelicula in peliculas)
            {
                if (pelicula.CantidadDisponible == 0)
                {
                    return BadRequest("La  Pelicula " + pelicula.Id + " no esta disponible");
                }

                var alquiler = new Alquiler()
                {
                    ClienteId = cliente.Id,
                    PeliculaId = pelicula.Id,
                    FechaAlquiler = DateTime.Now,
                    FechaDevolucion = DateTime.Today.AddDays(2)

                };

                _context.Alquileres.Add(alquiler);
            }

            _context.SaveChanges();

            return Ok();
        }

        public IHttpActionResult Get() {

            return Ok();
        }
    }
}
