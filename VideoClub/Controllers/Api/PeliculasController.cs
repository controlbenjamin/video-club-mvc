using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoClub.Entities;
using AutoMapper;
using VideoClub.DTOs;
using System.Web;

namespace VideoClub.Controllers.Api
{
    public class PeliculasController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public PeliculasController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET api/peliculas
        [HttpGet]
        public IEnumerable<PeliculaDTO> GetPeliculas()
        {

            return _context.Peliculas.ToList().Select(Mapper.Map<Pelicula, PeliculaDTO>);
        }

        //GET api/peliculas/1
        [HttpGet]
        public IHttpActionResult GetPelicula(int id)
        {

            var peliculaDB = _context.Peliculas.SingleOrDefault(p => p.Id == id);

            if (peliculaDB == null)
            {
                return NotFound();
            }


            return Ok(Mapper.Map<Pelicula, PeliculaDTO>(peliculaDB));
        }


        //POST api/peliculas
        [HttpPost]
        public IHttpActionResult PostPelicula(PeliculaDTO peliculaDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pelicula = Mapper.Map<PeliculaDTO, Pelicula>(peliculaDTO);

            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();

            //asignar el id para enviarlo en la request
            peliculaDTO.Id = pelicula.Id;

            return Created(new Uri(Request.RequestUri + "/" + peliculaDTO.Id), peliculaDTO);

        }


        //PUT api/peliculas/1
        [HttpPut]
        public void PutPelicula(int id, PeliculaDTO peliculaDTO)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }


            var peliculaDB = _context.Peliculas.SingleOrDefault(p => p.Id == id);

            if (peliculaDTO == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<PeliculaDTO, Pelicula>(peliculaDTO, peliculaDB);

            _context.SaveChanges();

            

        }


        //DELETE api/peliculas/1
        [HttpDelete]
        public IHttpActionResult DeletePelicula(int id)
        {

            var peliculaDb = _context.Peliculas.SingleOrDefault(p => p.Id == id);

            if (peliculaDb == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(peliculaDb);
            _context.SaveChanges();

            throw new HttpResponseException(HttpStatusCode.NoContent);

        }
    }
}
