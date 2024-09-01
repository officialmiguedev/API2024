using AcademyOnline.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AcademyOnline.View.Areas.Academia.Controllers
{
    public class HomeController : Controller
    {
        // GET: Academia/Home
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

        public ActionResult Cursos(int id)
        {
            List<Entities.Curso> cursos;
            try
            {
                ServiceRepository _service = new ServiceRepository();
                HttpResponseMessage response = _service.GetResponse("Curso");
                response.EnsureSuccessStatusCode();
                List<Entities.Curso> result = response.Content.ReadAsAsync<List<Entities.Curso>>().Result;
                cursos = result.Where(x => x.CategoriaId.Equals(id)).ToList();
                return View(cursos);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult DetallesCurso(int id)
        {
            List<Entities.Curso> _cursos;
            List<Entities.Leccion> _lecciones;
            List<Entities.Tema> _temas;

            ServiceRepository _service = new ServiceRepository();
            HttpResponseMessage response0 = _service.GetResponse("Curso");
            response0.EnsureSuccessStatusCode();
           _cursos = response0.Content.ReadAsAsync<List<Entities.Curso>>().Result;


            HttpResponseMessage response = _service.GetResponse("Curso?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Entities.Curso result = response.Content.ReadAsAsync<Entities.Curso>().Result;
           
            ViewBag.entity = result;

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