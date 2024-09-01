using AcademyOnline.DataAccess;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.WEB.Controllers
{
    public class LeccionController : Controller
    {
        // GET: Leccion
        // GET: Leccion

        List<Leccion> _list;


        public ActionResult Index()
        {
            using (LeccionDAL db = new LeccionDAL())
            {
                _list = db.SelectAll();
            }
            return View(_list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Tema> _tema;


            using (TemaDAL db = new TemaDAL())
            {
                _tema = db.SelectAll();
            }
            ViewBag.temas = new SelectList(_tema, "TemaId", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Leccion entity)
        {
            try
            {
                using (LeccionDAL db = new LeccionDAL())
                {
                   // ImagePath.SaveAs(Server.MapPath("~/Images/Categories/") + ImagePath.FileName);
                   //entity.ImagePath = ImagePath.FileName;
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
            using (LeccionDAL db = new LeccionDAL())
            {
                Leccion entity = db.SelectAll().FirstOrDefault(x => x.LeccionId.Equals(id));
                if (entity != null)
                {
                    ViewBag.temas = new SelectList(SelectTema(), "TemaId", "Nombre", entity.TemaId);
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Leccion entity)
        {
            try
            {
                using (LeccionDAL db = new LeccionDAL())
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


        public List<Tema> SelectTema()
        {
            List<Tema> result = null;
            using (TemaDAL _context = new TemaDAL())
            {
                result = _context.SelectAll();
            }
            return result;
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (LeccionDAL db = new LeccionDAL())
                {
                    Leccion entity = db.SelectAll().FirstOrDefault(x => x.LeccionId.Equals(id));
                    //System.IO.File.Delete(Server.MapPath("~/Images/Categories/") + entity.ImagePath);
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