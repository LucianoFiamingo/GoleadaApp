using DAL;
using DAL.Entities.EDMX;
using System.Collections.Generic;

namespace Services
{
    public class JugadoresService : IJugadoresService
    {
        protected GoleadaDBEntities contexto;
        protected JugadoresRepository repo;
        public JugadoresService(GoleadaDBEntities contexto)
        {
            this.contexto = contexto;
        }
        public void Alta(Jugador Jugador)
        {
            repo.Alta(Jugador);
        }

        public Jugador ObtenerPorId(int Id)
        {
            return repo.ObtenerPorId(Id);
        }

        public List<Jugador> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }
    }
}
