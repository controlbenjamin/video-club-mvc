namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertarRegistrosTablaTipoMembresia : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipoMembresia(Nombre, TarifaRegistro, DuracionEnMeses, TasaDescuento) VALUES('Prepago', 0, 0, 0)");
            Sql("INSERT INTO TipoMembresia(Nombre, TarifaRegistro, DuracionEnMeses, TasaDescuento) VALUES('Mensual', 30, 1, 10)");
            Sql("INSERT INTO TipoMembresia(Nombre, TarifaRegistro, DuracionEnMeses, TasaDescuento) VALUES('Trimestral', 90, 3, 15)");
            Sql("INSERT INTO TipoMembresia(Nombre, TarifaRegistro, DuracionEnMeses, TasaDescuento) VALUES('Anual', 300, 12, 20)");

        }

        public override void Down()
        {
        }
    }
}
