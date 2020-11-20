using DAL.Entities.EDMX;
using System.Collections.Generic;

namespace DAL
{
    public interface IJugadoresRepository
    {
        void Alta(Jugador Jugador);
        Jugador ObtenerPorId(int Id);
        List<Jugador> ObtenerTodos();
    }
}