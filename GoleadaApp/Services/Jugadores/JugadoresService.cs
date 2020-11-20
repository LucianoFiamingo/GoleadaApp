using DAL;
using DAL.Entities.EDMX;
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
