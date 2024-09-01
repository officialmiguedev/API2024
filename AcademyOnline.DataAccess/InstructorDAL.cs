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
    public class InstructorDAL : IDisposable
    {
        private readonly AppDBContext _db;
        private DbSet<Instructor> dbset;

        public InstructorDAL()
        {
            _db = new AppDBContext();
            dbset = _db.instructores;
        }

        public void Insert(Instructor entity)
        {
            dbset.Add(entity);
            _db.SaveChanges();
        }

        public List<Instructor> SelectAll()
        {
            return _db.instructores.ToList();
        }

        public Instructor Select(int id)
        {
            return _db.instructores.Find(id);
        }

        public void Update(Instructor id)
        {
            Instructor entity = _db.instructores.FirstOrDefault(x => x.InstructorId.Equals(id.InstructorId));
            if (entity != null)
            {
                entity.InstructorId = id.InstructorId;
                entity.Nombres = id.Nombres;
                entity.SobreMi = id.SobreMi;
                entity.Titulo = id.Titulo;
                entity.Youtube = id.Youtube;
                entity.Twitter = id.Twitter;
                entity.Linkedln = id.Linkedln;
                entity.ImagePath = id.ImagePath;
                //_db.Brands.Attach(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Instructor entity = _db.instructores.FirstOrDefault(x => x.InstructorId.Equals(id));
            if (entity != null)
            {
                _db.instructores.Remove(entity);
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
