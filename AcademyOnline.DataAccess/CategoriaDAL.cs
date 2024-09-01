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
    public class CategoriaDAL : IDisposable
    {
        private readonly AppDBContext _db;
        private DbSet<Categoria> dbset;

        public CategoriaDAL()
        {
            _db = new AppDBContext();
            dbset = _db.categorias;
        }

        public void Insert(Categoria entity)
        {
            dbset.Add(entity);
            _db.SaveChanges();
        }

        public List<Categoria> SelectAll()
        {
            return _db.categorias.ToList();
        }

        public Categoria Select(int id)
        {
            return _db.categorias.Find(id);
        }

        public void Update(Categoria id)
        {
            Categoria entity = _db.categorias.FirstOrDefault(x => x.CategoriaId.Equals(id.CategoriaId));
            if (entity != null)
            {
                entity.CategoriaId = id.CategoriaId;
                entity.Nombre = id.Nombre;
                //_db.Brands.Attach(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Categoria entity = _db.categorias.FirstOrDefault(x => x.CategoriaId.Equals(id));
            if (entity != null)
            {
                _db.categorias.Remove(entity);
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
