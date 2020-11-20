using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GolesRepository : IGolesRepository
    {
        protected Entities contexto;
        public GolesRepository(Entities contexto)
        {
            this.contexto = contexto;
        }
        public void Alta(GolesPorJugadorEquipo Goles)
        {
            contexto.GolesPorJugadorEquipoes.Add(Goles);
            contexto.SaveChanges();
        }

        public GolesPorJugadorEquipo ObtenerPorId(int Id)
        {
            var GolesQuery = from g in contexto.GolesPorJugadorEquipoes
                             where g.Id == Id
                             select g;

            GolesPorJugadorEquipo Goles = GolesQuery.First();

            return Goles;
        }

        public List<GolesPorJugadorEquipo> ObtenerTodos()
        {
            var GolesQuery = from g in contexto.GolesPorJugadorEquipoes
                             select g;

            List<GolesPorJugadorEquipo> ListaGoles = GolesQuery.ToList();

            return ListaGoles;
        }
    }
}