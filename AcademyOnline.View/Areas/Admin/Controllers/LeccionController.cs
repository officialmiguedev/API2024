using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.View.Areas.Admin.Controllers
{
    public class LeccionController : Controller
    {
        // GET: Admin/Leccion
        public ActionResult Index()
        {
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Leccion");
                response.EnsureSuccessStatusCode();
                List<Entities.Leccion> result = response.Content.ReadAsAsync<List<Entities.Leccion>>().Result;
                return View(result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Leccion/Leccion/Details/5
        public ActionResult Details(int id)
        {
            Entities.Leccion result;
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.GetResponse("Leccion?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                result = res.Content.ReadAsAsync<Entities.Leccion>().Result;

            }
            catch (Exception)
            {

            }


            return View();
        }

        // GET: Leccion/Leccion/Create


        // POST: Leccion/Leccion/Create
        [HttpPost]
        public ActionResult Create(Entities.Leccion entity, int CursoId, string nombreCurso)
        {

            try
            {
                //ImagePath.SaveAs(Server.MapPath("~/Areas/Images/Categories/") + ImagePath.FileName);
                //entity.ImagePath = ImagePath.FileName;
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Leccion/", entity);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Create/" + CursoId,"Tema", nombreCurso.ToString());
            }
            catch
            {
                return View();
            }
        }

        // GET: Leccion/Leccion/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response = _service.GetResponse("Leccion?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Leccion result = response.Content.ReadAsAsync<Entities.Leccion>().Result;
            return View(result);
        }

        // POST: Leccion/Leccion/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Leccion ent)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PutResponse("Leccion/", ent);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leccion/Leccion/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.DeleteResponse("Leccion?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Leccion/Leccion/Delete/5
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