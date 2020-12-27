using DAL.Entities.EDMX;
using Entities.VM;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class JugadoresController : Controller
    {
        JugadoresService JugadoresService;
        public JugadoresController()
        {
            GoleadaDBEntities contexto = new GoleadaDBEntities();
            JugadoresService = new JugadoresService(contexto);
        }
        public ActionResult ListaJugadores()
        {
            List<Jugador> Jugadores = JugadoresService.ObtenerTodos();
            return View(Jugadores);
        }

        public ActionResult AltaJugadores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaJugadores(JugadoresVM Jugadores)
        {
            if (!JugadoresService.Validar(Jugadores))
            {
                TempData["Creado"] = "FALSE";
                return View(Jugadores);
            }

            if (Jugadores.Nombres.Count() == 1)
            {
                TempData["Creado"] = JugadoresService.AltaJugadores(Jugadores);
            }
            else
            {
                TempData["Creados"] = JugadoresService.AltaJugadores(Jugadores);
            }
            return RedirectToAction("ListaJugadores");
        }

    }
}