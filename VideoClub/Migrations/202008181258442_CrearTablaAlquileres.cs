namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaAlquileres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alquileres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PeliculaId = c.Int(nullable: false),
                        FechaAlquiler = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Peliculas", t => t.PeliculaId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.PeliculaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alquileres", "PeliculaId", "dbo.Peliculas");
            DropForeignKey("dbo.Alquileres", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Alquileres", new[] { "PeliculaId" });
            DropIndex("dbo.Alquileres", new[] { "ClienteId" });
            DropTable("dbo.Alquileres");
        }
    }
}
