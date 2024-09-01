using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.View.Areas.Admin.Controllers
{
    public class CursoController : Controller
    {
        // GET: Admin/Curso
        public ActionResult Index()
        {
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Curso");
                response.EnsureSuccessStatusCode();
                List<Entities.Curso> result = response.Content.ReadAsAsync<List<Entities.Curso>>().Result;
                return View(result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Curso/Curso/Create
        public ActionResult Create()
        {
            List<Entities.Instructor> _listInstructore;
            List<Entities.Categoria> _listCategorias;

            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage instructores = _service.GetResponse("Instructor");
                HttpResponseMessage categorias = _service.GetResponse("Categoria");
                instructores.EnsureSuccessStatusCode();
                categorias.EnsureSuccessStatusCode();
                // List<Entities.Curso> result = response.Content.ReadAsAsync<List<Entities.Curso>>().Result;
                _listInstructore = instructores.Content.ReadAsAsync<List<Entities.Instructor>>().Result;
                _listCategorias = categorias.Content.ReadAsAsync<List<Entities.Categoria>>().Result;

                ViewBag.instructor = new SelectList(_listInstructore, "InstructorId", "Nombres");
                ViewBag.categories = new SelectList(_listCategorias, "CategoriaId", "Nombre");
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Curso/Curso/Create
        [HttpPost]
        public ActionResult Create(Entities.Curso entity, HttpPostedFileBase ImagePath)
        {

            try
            {
                ImagePath.SaveAs(Server.MapPath("~/Areas/Images/Cursos/") + ImagePath.FileName);
                entity.ImagePath = ImagePath.FileName;
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Curso/", entity);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Curso/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response = _service.GetResponse("Curso?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Curso result = response.Content.ReadAsAsync<Entities.Curso>().Result;
            return View(result);
        }

        // POST: Curso/Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Curso ent)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PutResponse("Curso/", ent);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Curso/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.DeleteResponse("Curso?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Curso/Curso/Delete/5
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