using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.View.Areas.Admin.Controllers
{
    public class TemaController : Controller
    {
        // GET: Admin/Tema
        public ActionResult Index()
        {
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Tema");
                response.EnsureSuccessStatusCode();
                List<Entities.Tema> result = response.Content.ReadAsAsync<List<Entities.Tema>>().Result;
                return View(result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Tema/Tema/Details/5
        public ActionResult Details(int id)
        {
            Entities.Tema result;
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.GetResponse("Tema?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                result = res.Content.ReadAsAsync<Entities.Tema>().Result;

            }
            catch (Exception)
            {

            }


            return View();
        }

        // GET: Tema/Tema/Create
        public ActionResult Create(int id, string nombre)
        {
            List<Entities.Tema> _lista;
            List<Entities.Tema> _listaCursoID;


            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Tema");
                response.EnsureSuccessStatusCode();

                 _lista = response.Content.ReadAsAsync<List<Entities.Tema>>().Result;
                _listaCursoID = _lista.Where(x => x.CursoId.Equals(id)).ToList();
                ViewBag.cursoID = id;
                ViewBag.nombreCurso = nombre;
                ViewBag.Temarios = new SelectList(_listaCursoID, "TemaId", "Nombre");

                List<Entities.Curso> _cursos;
                List<Entities.Leccion> _lecciones;
                List<Entities.Tema> _temas;

                HttpResponseMessage response0 = _service.GetResponse("Curso");
                response0.EnsureSuccessStatusCode();
                _cursos = response0.Content.ReadAsAsync<List<Entities.Curso>>().Result;

                HttpResponseMessage response1 = _service.GetResponse("Tema");
                response.EnsureSuccessStatusCode();
                List<Entities.Tema> result1 = response1.Content.ReadAsAsync<List<Entities.Tema>>().Result;
                _temas = result1;
                result1 = result1.Where(x => x.CursoId.Equals(id)).ToList();
                ViewBag.temas = result1;

                HttpResponseMessage response3 = _service.GetResponse("Leccion");
                response.EnsureSuccessStatusCode();
                List<Entities.Leccion> result3 = response3.Content.ReadAsAsync<List<Entities.Leccion>>().Result;
                _lecciones = result3;


                List<VMLeccion> list = (from a in _cursos
                                        from b in _lecciones
                                        from c in _temas
                                        where a.CursoId == id && c.CursoId == id && b.TemaId == c.TemaId
                                        select new VMLeccion
                                        {
                                            LeccionId = b.LeccionId,
                                            Nombre = b.Nombre,
                                            TemaId = b.TemaId,
                                            CursoId = c.CursoId,
                                            NombreCurso = a.Nombre
                                        }
                    ).ToList();

                ViewBag.Lecciones = list;
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: Tema/Tema/Create
        /* [HttpPost]
        public ActionResult Create(Entities.Tema entity)
        {

            try
            {
                //ImagePath.SaveAs(Server.MapPath("~/Areas/Images/Categories/") + ImagePath.FileName);
                //entity.ImagePath = ImagePath.FileName;
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Tema/", entity);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } */

        [HttpPost]
        public ActionResult Create(Entities.Tema entity)
        {
            
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PostResponse("Tema/", entity);
                res.EnsureSuccessStatusCode();
                return Redirect("Create/" + entity.CursoId);

               
            }
            catch
            {
                return View();
            }
        }



        // GET: Tema/Tema/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response = _service.GetResponse("Tema?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Tema result = response.Content.ReadAsAsync<Entities.Tema>().Result;
            return View(result);
        }

        // POST: Tema/Tema/Edit/5
        [HttpPost]
        public ActionResult Edit(Entities.Tema ent)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.PutResponse("Tema/", ent);
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tema/Tema/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository _serv = new ServiceRepository();
                HttpResponseMessage res = _serv.DeleteResponse("Tema?id=" + id.ToString());
                res.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Tema/Tema/Delete/5
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

    public class VMLeccion
    {
        public int LeccionId { get; set; }
        public string Nombre { get; set; }
        public int TemaId { get; set; }
        public int CursoId { get; set; }
        public string NombreCurso { get; set; }
    }
}