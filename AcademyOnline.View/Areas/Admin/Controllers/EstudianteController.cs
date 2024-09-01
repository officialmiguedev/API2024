using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.View.Areas.Admin.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Admin/Estudiante
        public ActionResult Index()
        {
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Estudiante");
                response.EnsureSuccessStatusCode();
                List<Entities.Estudiante> result = response.Content.ReadAsAsync<List<Entities.Estudiante>>().Result;
                return View(result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Estudiante/Estudiante/Details/5
        public ActionResult Details(int id)
        {
            Entities.Estudiante result;
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.GetResponse("Estudiante?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                result = res.Content.ReadAsAsync<Entities.Estudiante>().Result;

            }
            catch (Exception)
            {

            }


            return View();
        }

        // GET: Estudiante/Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Estudiante/Create
        [HttpPost]
        public ActionResult Create(Entities.Estudiante entity)
        {

            try
            {
               
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Estudiante/", entity);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response = _service.GetResponse("Estudiante?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Estudiante result = response.Content.ReadAsAsync<Entities.Estudiante>().Result;
            return View(result);
        }

        // POST: Estudiante/Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Estudiante ent)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PutResponse("Estudiante/", ent);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.DeleteResponse("Estudiante?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Estudiante/Estudiante/Delete/5
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