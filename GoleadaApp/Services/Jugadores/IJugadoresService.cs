using DAL.Entities.EDMX;
using Entities.VM;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Services
{
    public interface IJugadoresService
    {
        void Alta(Jugador Jugador);
        Jugador ObtenerPorId(int Id);
        List<Jugador> ObtenerTodos();
        string AltaJugadores(JugadoresVM Jugadores);
        bool Validar(JugadoresVM Jugadores);
        List<SelectListItem> ObtenerComboJugadores();
        List<SelectListItem> ObtenerComboJugadores(int IdJugador);
    }
}
