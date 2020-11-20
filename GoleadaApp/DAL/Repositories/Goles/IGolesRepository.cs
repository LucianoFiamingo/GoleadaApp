using System.Collections.Generic;

namespace DAL
{
    public interface IGolesRepository
    {
        void Alta(GolesPorJugadorEquipo Goles);
        GolesPorJugadorEquipo ObtenerPorId(int Id);
        List<GolesPorJugadorEquipo> ObtenerTodos();
    }
}