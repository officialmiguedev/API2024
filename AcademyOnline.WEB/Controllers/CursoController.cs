using AcademyOnline.DataAccess;
using AcademyOnline.DataAccess.Data;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.WEB.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso

        List<Curso> _list;

        
        public ActionResult Index()
        {
            using (CursoDAL db = new CursoDAL())
            {
                _list = db.SelectAll();
            }
            return View(_list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Instructor> _instuctor;
            List<Categoria> _categoria;


            using (InstructorDAL db = new InstructorDAL())
            {
                _instuctor = db.SelectAll();
            }
            ViewBag.instructor = new SelectList(_instuctor, "InstructorId", "Nombres");
            using (CategoriaDAL db = new CategoriaDAL())
            {
                _categoria = db.SelectAll();
            }
            ViewBag.categories = new SelectList(_categoria, "CategoriaId", "Nombre");
            return View();

        }

        [HttpPost]
        public ActionResult Create(Curso entity, HttpPostedFileBase ImagePath)
        {
            try
            {
                using (CursoDAL db = new CursoDAL())
                {
                    ImagePath.SaveAs(Server.MapPath("~/Images/Cursos/") + ImagePath.FileName);
                    entity.ImagePath = ImagePath.FileName;
                    db.Insert(entity);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (AppDBContext db = new AppDBContext())
            {
                CursoDAL dl = new CursoDAL();
                List<Tema> temas = db.temas.Where(x => x.CursoId.Equals(id)).ToList();
                ViewBag.temas = temas;
                List<VMLeccion> list = (from a in db.cursos
                                        from b in db.lecciones
                                        from c in db.temas
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
                Curso entity = dl.SelectAll().FirstOrDefault(x => x.CursoId.Equals(id));
                if (entity != null)
                {
                    ViewBag.instructor = new SelectList(SelectAllInstructor(), "InstructorId", "Nombre", entity.InstructorId);
                    ViewBag.categories = new SelectList(SelectAllCategories(), "CategoriaId", "Nombre", entity.CategoriaId);
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }

        public List<Instructor> SelectAllInstructor()
        {
            List<Instructor> result = null;
            using (InstructorDAL _context = new InstructorDAL())
            {
                result = _context.SelectAll();
            }
            return result;
        }

        public List<Categoria> SelectAllCategories()
        {
            List<Categoria> result = null;
            using (CategoriaDAL _context = new CategoriaDAL())
            {
                result = _context.SelectAll();
            }
            return result;
        }

        [HttpPost]
        public ActionResult Edit(Curso entity)
        {
            try
            {
                using (CursoDAL db = new CursoDAL())
                {
                    db.Update(entity);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (CursoDAL db = new CursoDAL())
                {
                    Curso entity = db.SelectAll().FirstOrDefault(x => x.CursoId.Equals(id));
                    System.IO.File.Delete(Server.MapPath("~/Images/Cursos/") + entity.ImagePath);
                    db.Delete(id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Error()
        {
            return View();
        }




    }
}