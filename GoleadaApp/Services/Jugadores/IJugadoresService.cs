using DAL;
using System.Collections.Generic;

namespace Services
{
    public interface IJugadoresService
    {
        void Alta(Jugador Jugador);
        Jugador ObtenerPorId(int Id);
        List<Jugador> ObtenerTodos();
    }
}
