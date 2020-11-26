using DAL;
using DAL.Entities.EDMX;
using Entities.VM;
using System;
using System.Collections.Generic;

namespace Services
{
    public class GolesService : IGolesService
    {
        protected GolesRepository repo;
        public GolesService(GoleadaDBEntities contexto)
        {
            repo = new GolesRepository(contexto);
        }
        public void Alta(GolesPorJugadorEquipo Goles)
        {
            repo.Alta(Goles);
        }

        public void AltaModificacion(GolesPorJugadorEquipo Goles)
        {
            repo.AltaModificacion(Goles);
        }

        public GolesPorJugadorEquipo ObtenerPorEquipoYNombreJugador(GolesPorJugadorEquipo Goles)
        {
            return repo.ObtenerPorEquipoYNombreJugador(Goles);
        }

        public GolesPorJugadorEquipo ObtenerPorId(int Id)
        {
            return repo.ObtenerPorId(Id);
        }

        public List<GolesPorJugadorEquipo> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public string TotalGolesEquipo(string equipo)
        {
            return repo.TotalGolesEquipo(equipo);
        } 
        
        public List<GolesEquipoVM> GolesPorEquipo()
        {
            return repo.GolesPorEquipo();
        }
    }
}
