using AcademyOnline.DataAccess;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.WEB.Controllers
{
    public class TemaController : Controller
    {
        // GET: Tema
        // GET: Tema

        List<Tema> _list;


        public ActionResult Index()
        {
            using (TemaDAL db = new TemaDAL())
            {
                _list = db.SelectAll();
            }
            return View(_list);
        }

        public ActionResult IndexAllById(int id)
        {
            using (TemaDAL db = new TemaDAL())
            {
                _list = db.SelectAllById(id);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Curso> curso;
            using (CursoDAL db = new CursoDAL())
            {
                curso = db.SelectAll();
            }
            ViewBag.cursos = new SelectList(curso, "CursoId", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tema entity)
        {
            try
            {
                using (TemaDAL db = new TemaDAL())
                {
                   // ImagePath.SaveAs(Server.MapPath("~/Images/Categories/") + ImagePath.FileName);
                   // entity.ImagePath = ImagePath.FileName;
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
            using (TemaDAL db = new TemaDAL())
            {
                Tema entity = db.SelectAll().FirstOrDefault(x => x.TemaId.Equals(id));
                if (entity != null)
                {
                    ViewBag.cursos = new SelectList(SelectCurso(), "CursoId", "Nombre", entity.CursoId);
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }

        public List<Curso> SelectCurso()
        {
            List<Curso> result = null;
            using (CursoDAL _context = new CursoDAL())
            {
                result = _context.SelectAll();
            }
            return result;
        }

        [HttpPost]
        public ActionResult Edit(Tema entity)
        {
            try
            {
                using (TemaDAL db = new TemaDAL())
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
                using (TemaDAL db = new TemaDAL())
                {
                    Tema entity = db.SelectAll().FirstOrDefault(x => x.TemaId.Equals(id));
                   // System.IO.File.Delete(Server.MapPath("~/Images/Categories/") + entity.ImagePath);
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