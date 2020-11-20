using DAL;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class GolesService : IGolesService
    {
        protected GolesRepository repo;
        public GolesService(Entities contexto)
        {
            repo = new GolesRepository(contexto);
        }
        public void Alta(GolesPorJugadorEquipo Goles)
        {
            repo.Alta(Goles);
        }

        public GolesPorJugadorEquipo ObtenerPorId(int Id)
        {
            return repo.ObtenerPorId(Id);
        }

        public List<GolesPorJugadorEquipo> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }
    }
}
