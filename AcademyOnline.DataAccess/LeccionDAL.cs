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
    public class LeccionDAL : IDisposable
    {
        private readonly AppDBContext _db;
        private DbSet<Leccion> dbset;

        public LeccionDAL()
        {
            _db = new AppDBContext();
            dbset = _db.lecciones;
        }

        public void Insert(Leccion entity)
        {
            dbset.Add(entity);
            _db.SaveChanges();
        }

        public List<Leccion> SelectAll()
        {
            return _db.lecciones.ToList();
        }

        public Leccion Select(int id)
        {
            return _db.lecciones.Find(id);
        }

        public void Update(Leccion id)
        {
            Leccion entity = _db.lecciones.FirstOrDefault(x => x.LeccionId.Equals(id.LeccionId));
            if (entity != null)
            {
                entity.LeccionId = id.LeccionId;
                entity.Nombre = id.Nombre;
                entity.TemaId = id.TemaId;
                //_db.Brands.Attach(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Leccion entity = _db.lecciones.FirstOrDefault(x => x.LeccionId.Equals(id));
            if (entity != null)
            {
                _db.lecciones.Remove(entity);
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
