using AcademyOnline.DataAccess;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.WEB.Controllers
{
    public class CategoriaController : Controller
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria entity, HttpPostedFileBase ImagePath)
        {
            try
            {
                using (CategoriaDAL db = new CategoriaDAL())
                {
                    ImagePath.SaveAs(Server.MapPath("~/Images/Categories/") + ImagePath.FileName);
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
            using (CategoriaDAL db = new CategoriaDAL())
            {
                Categoria entity = db.SelectAll().FirstOrDefault(x => x.CategoriaId.Equals(id));
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
        public ActionResult Edit(Categoria entity)
        {
            try
            {
                using (CategoriaDAL db = new CategoriaDAL())
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
                using (CategoriaDAL db = new CategoriaDAL())
                {
                    Categoria entity = db.SelectAll().FirstOrDefault(x => x.CategoriaId.Equals(id));
                    System.IO.File.Delete(Server.MapPath("~/Images/Categories/") + entity.ImagePath);
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