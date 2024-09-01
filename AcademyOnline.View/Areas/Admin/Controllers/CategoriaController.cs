using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AcademyOnline.Entities;

namespace AcademyOnline.View.Areas.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Admin/Categoria
        public ActionResult Index()
        {
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Categoria");
                response.EnsureSuccessStatusCode();
                List<Entities.Categoria> result = response.Content.ReadAsAsync<List<Entities.Categoria>>().Result;
                return View(result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Categoria/Categoria/Details/5
        public ActionResult Details(int id)
        {
            Entities.Categoria result;
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.GetResponse("Categoria?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                result = res.Content.ReadAsAsync<Entities.Categoria>().Result;

            }
            catch (Exception)
            {

            }


            return View();
        }

        // GET: Categoria/Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Categoria/Create
        [HttpPost]
        public ActionResult Create(Entities.Categoria entity, HttpPostedFileBase ImagePath)
        {
            
            try
            {
                ImagePath.SaveAs(Server.MapPath("~/Areas/Images/Categories/") + ImagePath.FileName);
                entity.ImagePath = ImagePath.FileName;
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Categoria/",entity);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response = _service.GetResponse("Categoria?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Categoria result = response.Content.ReadAsAsync<Entities.Categoria>().Result;
            return View(result);
        }

        // POST: Categoria/Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Categoria ent)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PutResponse("Categoria/",ent);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.DeleteResponse("Categoria?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Categoria/Categoria/Delete/5
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