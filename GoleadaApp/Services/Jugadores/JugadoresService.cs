using DAL;
using System.Collections.Generic;

namespace Services
{
    public class JugadoresService : IJugadoresService
    {
        protected Entities contexto;
        protected JugadoresRepository repo;
        public JugadoresService(Entities contexto)
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
