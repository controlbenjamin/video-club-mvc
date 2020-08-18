namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnaCantidadDisponibleToTablaPeliculas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Peliculas", "CantidadDisponible", c => c.Int(nullable: false));

            Sql("UPDATE Peliculas SET CantidadDisponible = Stock ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Peliculas", "CantidadDisponible");
        }
    }
}
