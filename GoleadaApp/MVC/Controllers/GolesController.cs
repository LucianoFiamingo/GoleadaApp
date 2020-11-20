using DAL.Entities.EDMX;
using Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class GolesController : Controller
    {
        GolesService GolesService;
        JugadoresService JugadoresService;
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

    }
}