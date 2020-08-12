namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarRegistroPruebaTablaClientes_TablaPeliculas : DbMigration
    {
        public override void Up()
        {
            //agregar clientes
            Sql("INSERT INTO Clientes(Nombre, EstaSuscritoNoticias, TipoMembresiaId, FechaNacimiento) " +
                "VALUES('Benjamin Correa', 0, 1, '1985-12-20')");
            Sql("INSERT INTO Clientes(Nombre, EstaSuscritoNoticias, TipoMembresiaId, FechaNacimiento) " +
               "VALUES('Miriam Perez', 1, 2, null)");
            Sql("INSERT INTO Clientes(Nombre, EstaSuscritoNoticias, TipoMembresiaId, FechaNacimiento) " +
               "VALUES('Pablo Spitale', 1, 3, null)");
            Sql("INSERT INTO Clientes(Nombre, EstaSuscritoNoticias, TipoMembresiaId, FechaNacimiento) " +
               "VALUES('Sol Cruz', 0, 4, '1980-05-07')");

            //agregar peliculas
            Sql("INSERT INTO Peliculas(Nombre, FechaLanzamiento, FechaAlta, Stock, GeneroId) " +
               "VALUES('Freddy', '1980-05-07','1980-05-07', 6, 4 )");
            Sql("INSERT INTO Peliculas(Nombre, FechaLanzamiento, FechaAlta, Stock, GeneroId) " +
           "VALUES('Titanic', '2000-01-01','2004-05-05', 15, 7 )");
            Sql("INSERT INTO Peliculas(Nombre, FechaLanzamiento, FechaAlta, Stock, GeneroId) " +
           "VALUES('Ace Ventura', '1996-02-02','1998-11-07', 4, 2 )");
            Sql("INSERT INTO Peliculas(Nombre, FechaLanzamiento, FechaAlta, Stock, GeneroId) " +
           "VALUES('Donde están las rubias', '2005-10-02','2006-09-09', 1, 2 )");
            Sql("INSERT INTO Peliculas(Nombre, FechaLanzamiento, FechaAlta, Stock, GeneroId) " +
           "VALUES('Terminator', '1985-12-20','2010-10-10', 25, 1 )");

        }

        public override void Down()
        {
            Sql("DELETE FROM Clientes ");
            Sql("DELETE FROM Peliculas ");
        }
    }
}
