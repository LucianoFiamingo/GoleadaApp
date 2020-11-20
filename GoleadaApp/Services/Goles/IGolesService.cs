using DAL;
using System.Collections.Generic;

namespace Services
{
    public interface IGolesService
    {
        void Alta(GolesPorJugadorEquipo Goles);
        GolesPorJugadorEquipo ObtenerPorId(int Id);
        List<GolesPorJugadorEquipo> ObtenerTodos();
    }
}
