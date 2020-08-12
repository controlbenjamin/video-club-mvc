using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VideoClub.Entities;
using System.Data.Entity;
using VideoClub.Models;
using System.Data.Entity.Validation;

namespace VideoClub.Controllers
{
    public class PeliculasController : Controller
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


        public ActionResult Index()
        {

            var peliculas = _context.Peliculas.Include(p => p.Genero).ToList();


            var viewModel = new PeliculasViewModel()
            {
                Peliculas = peliculas
            };

            return View(viewModel);
        }


        public ActionResult Detalles(int id)
        {

            var pelicula = _context.Peliculas.Include(p => p.Genero).SingleOrDefault(p => p.Id == id);


            var viewModel = new PeliculasViewModel()
            {
                Pelicula = pelicula
            };

            return View(viewModel);
        }


        public ActionResult Nueva()
        {

            var generos = _context.Generos.ToList();

            var viewModel = new PeliculasViewModel()
            {
               Generos = generos
            };


            return View("PeliculaForm", viewModel);
        }


        [HttpPost]
        public ActionResult Guardar(Pelicula pelicula)
        {


            if (pelicula.Id == 0)
            {
                _context.Peliculas.Add(pelicula);
            }
            else
            {

                var peliculaDb = _context.Peliculas.Single(c => c.Id == pelicula.Id);

                peliculaDb.Nombre = pelicula.Nombre;
                peliculaDb.FechaLanzamiento = pelicula.FechaLanzamiento;
                peliculaDb.FechaAlta = pelicula.FechaAlta;
                peliculaDb.Stock = pelicula.Stock;
                peliculaDb.GeneroId = pelicula.GeneroId;

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            

            return RedirectToAction("Index");
        }



        public ActionResult Editar(int id)
        {

            var pelicula = _context.Peliculas.SingleOrDefault(p => p.Id == id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }


            var viewModel = new PeliculasViewModel()
            {

                Pelicula = pelicula,
                Generos = _context.Generos.ToList()
            };

            return View("PeliculaForm", viewModel);
        }
    }
}