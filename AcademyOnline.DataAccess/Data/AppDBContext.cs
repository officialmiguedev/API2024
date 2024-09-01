using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyOnline.DataAccess.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("conn")
        {

        }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<DetalleCurso> detallesCursos { get; set; }
        public DbSet<Estudiante> estaudiantes { get; set; }
        public DbSet<Instructor> instructores { get; set; }
        public DbSet<Leccion> lecciones { get; set; }
        public DbSet<Tema> temas { get; set; }

    }
}
