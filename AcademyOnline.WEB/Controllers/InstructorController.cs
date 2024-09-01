using AcademyOnline.DataAccess;
using AcademyOnline.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.WEB.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        // GET: Instructor

        List<Instructor> _list;


        public ActionResult Index()
        {
            using (InstructorDAL db = new InstructorDAL())
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
        public ActionResult Create(Instructor entity, HttpPostedFileBase ImagePath)
        {
            try
            {
                using (InstructorDAL db = new InstructorDAL())
                {
                    ImagePath.SaveAs(Server.MapPath("~/Images/Instructor/") + ImagePath.FileName);
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
            using (InstructorDAL db = new InstructorDAL())
            {
                Instructor entity = db.SelectAll().FirstOrDefault(x => x.InstructorId.Equals(id));
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
        public ActionResult Edit(Instructor entity)
        {
            try
            {
                using (InstructorDAL db = new InstructorDAL())
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
                using (InstructorDAL db = new InstructorDAL())
                {
                    Instructor entity = db.SelectAll().FirstOrDefault(x => x.InstructorId.Equals(id));
                    System.IO.File.Delete(Server.MapPath("~/Images/Instructor/") + entity.ImagePath);
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