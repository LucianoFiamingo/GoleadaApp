using DAL;
using DAL.Entities.EDMX;
using Entities.VM;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Services
{
    public class JugadoresService : IJugadoresService
    {
        protected JugadoresRepository repo;
        public JugadoresService(GoleadaDBEntities contexto)
        {
            repo = new JugadoresRepository(contexto);
        }
        public void Alta(Jugador Jugador)
        {
            repo.Alta(Jugador);
        }

        public Jugador ObtenerPorId(int Id)
        {
            return repo.ObtenerPorId(Id);
        }

        public List<Jugador> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public string AltaJugadores(JugadoresVM Jugadores)
        {
            int ultimo = Jugadores.Nombres.Count();
            int count = 1;
            string mensaje = null;

            foreach (var jug in Jugadores.Nombres)
            {
                Jugador jugNuevo = new Jugador();
                jugNuevo.Nombre = jug;
                Alta(jugNuevo);

                if (count == ultimo - 1)
                {
                    mensaje += jugNuevo.Nombre.ToString() + " y ";
                    count++;
                }
                else if (count == ultimo)
                {
                    mensaje += jugNuevo.Nombre.ToString();
                }
                else
                {
                    mensaje += jugNuevo.Nombre.ToString() + ", ";
                    count++;
                }
            }
            return mensaje;
        }

        public bool Validar(JugadoresVM Jugadores)
        {
            foreach (var jug in Jugadores.Nombres)
            {
                if (jug == null || jug.Length < 4 || jug.Length > 80)
                {
                    return false;
                }
            }
            return true;
        }
        public List<SelectListItem> ObtenerComboJugadores()
        {
            List<Jugador> jugs = repo.ObtenerTodos();

            List<SelectListItem> comboJugs = jugs.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.Id.ToString()
            }).ToList();

            comboJugs.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione un jugador" });

            return comboJugs;
        }
        public List<SelectListItem> ObtenerComboJugadores(int IdJugador)
        {
            List<Jugador> jugs = repo.ObtenerTodos();

            List<SelectListItem> comboJugs = jugs.Select(o => new SelectListItem()
            {
                Text = o.Nombre,
                Value = o.Id.ToString(),
                Selected = o.Id == IdJugador
            }).ToList();

            comboJugs.Insert(0, new SelectListItem() { Value = "", Text = "Seleccione un jugador" });

            return comboJugs;
        }
    }
}
