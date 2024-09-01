namespace AcademyOnline.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Fecha = c.DateTime(nullable: false),
                        InstructorId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.DetalleCursoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 1000),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Clave = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.EstudianteId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        SobreMi = c.String(nullable: false, maxLength: 50),
                        Youtube = c.String(nullable: false, maxLength: 50),
                        Linkedln = c.String(nullable: false, maxLength: 50),
                        Twitter = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.InstructorId);
            
            CreateTable(
                "dbo.Leccions",
                c => new
                    {
                        LeccionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        TemaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeccionId);
            
            CreateTable(
                "dbo.Temas",
                c => new
                    {
                        TemaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TemaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Temas");
            DropTable("dbo.Leccions");
            DropTable("dbo.Instructors");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.DetalleCursoes");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Categorias");
        }
    }
}
