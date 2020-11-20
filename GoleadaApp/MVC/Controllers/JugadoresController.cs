using DAL.Entities.EDMX;
using Services;
using System.Collections.Generic;
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
        public ActionResult AltaJugador()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaJugador(Jugador Jugador)
        {
            if (!ModelState.IsValid)
            {
                TempData["Creado"] = "FALSE";
                return View(Jugador);
            }

            JugadoresService.Alta(Jugador);
            TempData["Creado"] = Jugador.Nombre.ToString();
            return RedirectToAction("ListaJugadores");

        }

    }
}