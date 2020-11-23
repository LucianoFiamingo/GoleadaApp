using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    public class GolesDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Equipo { get; set; }
        public int IdJugador { get; set; }
    }
}