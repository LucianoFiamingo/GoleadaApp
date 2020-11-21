using DAL.Entities.EDMX;
using System.Collections.Generic;

namespace Services
{
    public interface IGolesService
    {
        void Alta(GolesPorJugadorEquipo Goles);
        void AltaModificacion(GolesPorJugadorEquipo Goles);
        GolesPorJugadorEquipo ObtenerPorId(int Id);
        List<GolesPorJugadorEquipo> ObtenerTodos();
        GolesPorJugadorEquipo ObtenerPorEquipoYNombreJugador(GolesPorJugadorEquipo Goles);
        string TotalGolesEquipo(string equipo);
    }
}
