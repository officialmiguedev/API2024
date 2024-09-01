using AcademyOnline.DataAccess;
using AcademyOnline.DataAccess.Data;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Query;

namespace AcademyOnline.WEB.Controllers
{
    public class HomeController : Controller
    {
        List<Categoria> _list;

        // GET: Categories
        public ActionResult Index()
        {
            using (CategoriaDAL db = new CategoriaDAL())
            {
                _list = db.SelectAll();
            }
            return View(_list);
        }


        public ActionResult Cursos(int id)
        {
            using (CursoDAL db = new CursoDAL())
            {
                var entity = db.SelectAll().Where(x => x.CategoriaId == id).ToList();
                if (entity != null)
                {
                    return View(entity);
                }
                else
                {
                    // bool verificar = false;
                    //int check = 1;
                    //ViewBag.aviso = verificar;
                    return RedirectToAction("Error");
                }
            }
        }


        public ActionResult VerCurso(int id)
        {
            using (CursoDAL db = new CursoDAL())
            {
                var entity = db.Select(id);
                ViewBag.entity = entity;
            }

            using (AppDBContext db = new AppDBContext())
            {
                List<Tema> temas = db.temas.Where(x => x.CursoId.Equals(id)).ToList();
                ViewBag.temas = temas;
            }

            using (AppDBContext _db = new AppDBContext())
            {
                /*var lis = (from a in _db.cursos
                               from b in _db.lecciones
                               from c in _db.temas
                               where a.CursoId == id && c.CursoId == id && b.TemaId == c.TemaId
                               select new
                               {
                                 Nombre =  b.Nombre,
                                 ID = c.TemaId,
                               }
                     ).ToList(); */

                List<VMLeccion> list = (from a in _db.cursos
                                        from b in _db.lecciones
                                        from c in _db.temas
                                        where a.CursoId == id && c.CursoId == id && b.TemaId == c.TemaId
                                        select new VMLeccion
                                        {
                                            LeccionId = b.LeccionId,
                                            Nombre = b.Nombre,
                                            TemaId = b.TemaId,
                                            CursoId = c.CursoId,
                                            NombreCurso = a.Nombre
                                        }
                    ).ToList();

                ViewBag.Lecciones = list;
            }
            return View();
        }


        public void Lecciones(int id)
        {

        }

        public ActionResult Instructor()
        {
            return View();

        }

        public ActionResult VistaCurso()
        {
            return View();

        }


       
    }

    public class VMLeccion
    {
        public int LeccionId { get; set; }
        public string Nombre { get; set; }
        public int TemaId { get; set; }
        public int CursoId { get; set; }
        public string NombreCurso { get; set; }
    }
}