using DAL.Entities.EDMX;
using Newtonsoft.Json;
using Services;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GolesController : Controller
    {
        private readonly GolesService GolesService;
        private readonly JugadoresService JugadoresService;
        public GolesController()
        {
            GoleadaDBEntities contexto = new GoleadaDBEntities();
            GolesService = new GolesService(contexto);
            JugadoresService = new JugadoresService(contexto);
        }
        public ActionResult ListaGolesJugador()
        {
            List<GolesPorJugadorEquipo> Goles = GolesService.ObtenerTodos();
            return View(Goles);
        }
        public ActionResult AltaGolesJugador()
        {
            ViewBag.ListaJugadores = JugadoresService.ObtenerComboJugadores();
            return View();
        }

        [HttpPost]
        public ActionResult AltaGolesJugador(GolesPorJugadorEquipo goles)
        {
            if (!ModelState.IsValid)
            {
                TempData["Creado"] = "FALSE";
                ViewBag.ListaJugadores = JugadoresService.ObtenerComboJugadores(goles.IdJugador);
                return View(goles);
            }

            GolesService.AltaModificacion(goles);
            TempData["Creado"] = JugadoresService.ObtenerPorId(goles.IdJugador).Nombre.ToString();
            return RedirectToAction("ListaGolesJugador");
        }

        public ActionResult GolesPruebaApi(string id)
        {
            ViewBag.Equipo = id;
            ViewBag.Cant = GetGolesEquipo(id);
            return View();
        }

        private string GetGolesEquipo(string id)
        {
            var url = $"https://localhost:44350/api/cantidadtotalgolesequipoapi/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return id;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<string>(responseBody);
                        return result;
                    }
                }
            }
        }
    }
}