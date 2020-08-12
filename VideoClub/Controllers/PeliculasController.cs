using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VideoClub.Entities;
using System.Data.Entity;
using VideoClub.Models;

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
    }
}