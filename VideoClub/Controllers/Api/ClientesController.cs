using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using VideoClub.DTOs;
using VideoClub.Entities;

using System.Data.Entity;


namespace VideoClub.Controllers.Api
{
    public class ClientesController : ApiController
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

        //GET => api/clientes
        [System.Web.Http.HttpGet]
        public IEnumerable<ClienteDTO> GetClientes()
        {
            return _context.Clientes
                .Include(c => c.TipoMembresia)
                .ToList()
                .Select(Mapper.Map<Cliente, ClienteDTO>);
        }


        //GET => api/clientes/1
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);


            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Cliente, ClienteDTO>(cliente));
        }

        //POST => api/clientes
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostCliente(ClienteDTO clienteDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = Mapper.Map<ClienteDTO, Cliente>(clienteDTO);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            clienteDTO.Id = cliente.Id;
            //por convencion Rest debe devolver la url con el id del nuevo cliente creado ejp:
            //  api/clientes/10

            return Created(new Uri(Request.RequestUri + "/" + cliente.Id), clienteDTO);
        }

        //PUT => api/clientes/1
        [System.Web.Http.HttpPut]
        public void PutCliente(int id, ClienteDTO clienteDTO)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var clienteDB = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (clienteDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            Mapper.Map<ClienteDTO, Cliente>(clienteDTO, clienteDB);

            /*
            clienteDB.Nombre = clienteDTO.Nombre;
            clienteDB.EstaSuscritoNoticias = clienteDTO.EstaSuscritoNoticias;
            clienteDB.TipoMembresiaId = clienteDTO.TipoMembresiaId;
            clienteDB.FechaNacimiento = clienteDTO.FechaNacimiento;
            */
            _context.SaveChanges();
        }



        //DELETE => api/clientes/1
        [System.Web.Http.HttpDelete]
        public void DeleteCliente(int id)
        {

            var clienteDB = _context.Clientes.SingleOrDefault(c => c.Id == id);


            if (clienteDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Clientes.Remove(clienteDB);
            _context.SaveChanges();
        }

    }
}
