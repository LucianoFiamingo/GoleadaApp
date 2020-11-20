using DAL.Entities.EDMX;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Services
{
    public interface IJugadoresService
    {
        void Alta(Jugador Jugador);
        Jugador ObtenerPorId(int Id);
        List<Jugador> ObtenerTodos();
        List<SelectListItem> ObtenerComboJugadores();
        List<SelectListItem> ObtenerComboJugadores(int IdJugador);
    }
}
