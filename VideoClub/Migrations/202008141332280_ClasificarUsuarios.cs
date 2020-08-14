namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClasificarUsuarios : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2294f9ed-ab99-4f3c-8598-eddd56a5844b', N'admin@ibm.com', 0, N'AP3GYXn8dRUa1DgO6ePQRuU741aU1lvidvxx6pkKh+SotHd1zn/LQpviMVe7lMKxaQ==', N'872b559a-705f-4397-b640-46dee423c3e7', NULL, 0, 0, NULL, 1, 0, N'admin@ibm.com');
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de8ef6a5-3be0-4b73-bbb1-383aca54e644', N'invitado@ibm.com', 0, N'AN+NErvsY+Vnaoq1PQGCelSouDXmZ4dBRoG6R491e23T0GaYtqrduphG/IWkdRhIZw==', N'add576f2-fdbd-4b48-a77d-a0921753442e', NULL, 0, 0, NULL, 1, 0, N'invitado@ibm.com');

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'34954c66-830c-42c3-bba9-11355cacabaf', N'PuedeAdministrarPeliculas');

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2294f9ed-ab99-4f3c-8598-eddd56a5844b', N'34954c66-830c-42c3-bba9-11355cacabaf')


");
        }
        
        public override void Down()
        {
        }
    }
}
