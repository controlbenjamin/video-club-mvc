using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoClub.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<TipoMembresia> TipoMembresia { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Alquiler> Alquileres { get; set; }




    }
}