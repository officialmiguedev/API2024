using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.View.Areas.Admin.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Admin/Instructor
        public ActionResult Index()
        {
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Instructor");
                response.EnsureSuccessStatusCode();
                List<Entities.Instructor> result = response.Content.ReadAsAsync<List<Entities.Instructor>>().Result;
                return View(result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Instructor/Instructor/Details/5
        public ActionResult Details(int id)
        {
            Entities.Instructor result;
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.GetResponse("Instructor?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                result = res.Content.ReadAsAsync<Entities.Instructor>().Result;

            }
            catch (Exception)
            {

            }


            return View();
        }

        // GET: Instructor/Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Instructor/Create
        [HttpPost]
        public ActionResult Create(Entities.Instructor entity, HttpPostedFileBase ImagePath)
        {

            try
            {
                ImagePath.SaveAs(Server.MapPath("~/Areas/Images/Instructor/") + ImagePath.FileName);
                entity.ImagePath = ImagePath.FileName;
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Instructor/", entity);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Instructor/Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response = _service.GetResponse("Instructor?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Instructor result = response.Content.ReadAsAsync<Entities.Instructor>().Result;
            return View(result);
        }

        // POST: Instructor/Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Instructor ent)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PutResponse("Instructor/", ent);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.DeleteResponse("Instructor?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Instructor/Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}