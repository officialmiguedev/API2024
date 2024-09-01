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
    public class EstudianteDAL : IDisposable
    {
        private readonly AppDBContext _db;
        private DbSet<Estudiante> dbset;

        public EstudianteDAL()
        {
            _db = new AppDBContext();
            dbset = _db.estaudiantes;
        }

        public void Insert(Estudiante entity)
        {
            dbset.Add(entity);
            _db.SaveChanges();
        }

        public List<Estudiante> SelectAll()
        {
            return _db.estaudiantes.ToList();
        }

        public Estudiante Select(int id)
        {
            return _db.estaudiantes.Find(id);
        }

        public void Update(Estudiante id)
        {
            Estudiante entity = _db.estaudiantes.FirstOrDefault(x => x.EstudianteId.Equals(id.EstudianteId));
            if (entity != null)
            {
                entity.EstudianteId = id.EstudianteId;
                entity.Nombre = id.Nombre;
                entity.Apellido = id.Apellido;
                entity.Email = id.Email;
                entity.Clave = id.Clave;
                //_db.Brands.Attach(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Estudiante entity = _db.estaudiantes.FirstOrDefault(x => x.EstudianteId.Equals(id));
            if (entity != null)
            {
                _db.estaudiantes.Remove(entity);
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
