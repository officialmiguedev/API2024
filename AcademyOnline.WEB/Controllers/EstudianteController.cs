using AcademyOnline.DataAccess;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.WEB.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        // GET: Estudiante

        List<Estudiante> _list;


        public ActionResult Index()
        {
            using (EstudianteDAL db = new EstudianteDAL())
            {
                _list = db.SelectAll();
            }
            return View(_list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Estudiante entity)
        {
            try
            {
                using (EstudianteDAL db = new EstudianteDAL())
                {
                    //ImagePath.SaveAs(Server.MapPath("~/Images/Categories/") + ImagePath.FileName);
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
            using (EstudianteDAL db = new EstudianteDAL())
            {
                Estudiante entity = db.SelectAll().FirstOrDefault(x => x.EstudianteId.Equals(id));
                if (entity != null)
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Estudiante entity)
        {
            try
            {
                using (EstudianteDAL db = new EstudianteDAL())
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
                using (EstudianteDAL db = new EstudianteDAL())
                {
                    Estudiante entity = db.SelectAll().FirstOrDefault(x => x.EstudianteId.Equals(id));
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