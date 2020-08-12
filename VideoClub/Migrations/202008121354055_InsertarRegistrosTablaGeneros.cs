namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertarRegistrosTablaGeneros : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Generos(Nombre) VALUES ('Acci�n')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Comedia')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Drama')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Terror')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Thriller')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Anime')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Rom�ntica')");
            Sql("INSERT INTO Generos(Nombre) VALUES ('Suspenso')");
        }
        
        public override void Down()
        {
        }
    }
}
