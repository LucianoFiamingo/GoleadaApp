//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Entities.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class GolesPorJugadorEquipo
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Equipo { get; set; }
        public int IdJugador { get; set; }
    
        public virtual Jugador Jugador { get; set; }
    }
}
