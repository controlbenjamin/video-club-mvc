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
    public class ClientesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var clientes = _context.Clientes.Include(c => c.TipoMembresia).ToList();

            var viewModel = new ClientesViewModel()
            {
                Clientes = clientes
            };

            return View(viewModel);
        }


        public ActionResult Detalles(int id)
        {

            var cliente = _context.Clientes.Include(c => c.TipoMembresia).SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ClientesViewModel()
            {
                Cliente = cliente
            };

            return View(viewModel);
        }





        public ActionResult Nuevo()
        {

            var tiposDeMembresia = _context.TipoMembresia.ToList();

            var viewModel = new ClientesViewModel()
            {
                Cliente = new Cliente(),
                TipoMembresias = tiposDeMembresia
            };


            return View("ClienteForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(Cliente cliente)
        {


            if (!ModelState.IsValid)
            {


                var viewModel = new ClientesViewModel() {

                    Cliente = cliente,
                    TipoMembresias = _context.TipoMembresia.ToList()
                };


                return View("ClienteForm", viewModel);
            }


            if (cliente.Id == 0)
            {
                _context.Clientes.Add(cliente);
            }
            else
            {

                var clienteDb = _context.Clientes.Single(c => c.Id == cliente.Id);

                clienteDb.Nombre = cliente.Nombre;
                clienteDb.FechaNacimiento = cliente.FechaNacimiento;
                clienteDb.TipoMembresiaId = cliente.TipoMembresiaId;
                clienteDb.EstaSuscritoNoticias = cliente.EstaSuscritoNoticias;
            }


            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult Editar(int id)
        {

            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }


            var viewModel = new ClientesViewModel()
            {

                Cliente = cliente,
                TipoMembresias = _context.TipoMembresia.ToList()
            };

            return View("ClienteForm", viewModel);
        }


    }
}