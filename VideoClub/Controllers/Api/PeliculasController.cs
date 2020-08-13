using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoClub.Entities;

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


        


    }
}
