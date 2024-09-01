using AcademyOnline.DataAccess.Data;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyOnline.DataAccess
{
    public class CursoDAL : IDisposable
    {
        private readonly AppDBContext _db;
        private DbSet<Curso> dbset;

        public CursoDAL()
        {
            _db = new AppDBContext();
            dbset = _db.cursos;
        }

        public void Insert(Curso entity)
        {
            dbset.Add(entity);
            _db.SaveChanges();
        }

        public List<Curso> SelectAll()
        {
            return _db.cursos.ToList();
        }

        public Curso Select(int id)
        {
            return _db.cursos.Find(id);
        }

        public void Update(Curso id)
        {
            Curso entity = _db.cursos.FirstOrDefault(x => x.CursoId.Equals(id.CursoId));
            if (entity != null)
            {
                entity.CursoId = id.CursoId;
                entity.Nombre = id.Nombre;
                entity.Fecha = id.Fecha;
                entity.InstructorId = id.InstructorId;
                entity.ImagePath = id.ImagePath;
                //_db.Brands.Attach(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Curso entity = _db.cursos.FirstOrDefault(x => x.CursoId.Equals(id));
            if (entity != null)
            {
                _db.cursos.Remove(entity);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
