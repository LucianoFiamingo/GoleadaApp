using DAL.Entities.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class JugadoresRepository : IJugadoresRepository
    {
        protected GoleadaDBEntities contexto;
        public JugadoresRepository(GoleadaDBEntities contexto)
        {
            this.contexto = contexto;
        }
        public void Alta(Jugador Jugador)
        {
            contexto.Jugadors.Add(Jugador);
            contexto.SaveChanges();
        }

        public Jugador ObtenerPorId(int Id)
        {
            var JugadorQuery = from j in contexto.Jugadors
                             where j.Id == Id
                             select j;

            Jugador Jugador = JugadorQuery.First();

            return Jugador;
        }

        public List<Jugador> ObtenerTodos()
        {
            var JugadoresQuery = from j in contexto.Jugadors
                                 orderby j.Nombre
                             select j;

            List<Jugador> ListaJugadores = JugadoresQuery.ToList();

            return ListaJugadores;
        }
    }
}