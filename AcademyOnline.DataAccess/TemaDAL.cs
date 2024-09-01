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
    public class TemaDAL : IDisposable
    {
        private readonly AppDBContext _db;
        private DbSet<Tema> dbset;

        public TemaDAL()
        {
            _db = new AppDBContext();
            dbset = _db.temas;
        }

        public void Insert(Tema entity)
        {
            dbset.Add(entity);
            _db.SaveChanges();
        }

        public List<Tema> SelectAll()
        {
            return _db.temas.ToList();
        }

        public Tema Select(int id)
        {
            return _db.temas.Find(id);
        }

        public List<Tema> SelectAllById(int id)
        {
            return _db.temas.Where(x => x.TemaId.Equals(id)).ToList();
        }

        public void Update(Tema id)
        {
            Tema entity = _db.temas.FirstOrDefault(x => x.TemaId.Equals(id.TemaId));
            if (entity != null)
            {
                entity.TemaId = id.TemaId;
                entity.Nombre = id.Nombre;
                entity.CursoId = id.CursoId;
                //_db.Brands.Attach(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Tema entity = _db.temas.FirstOrDefault(x => x.TemaId.Equals(id));
            if (entity != null)
            {
                _db.temas.Remove(entity);
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
