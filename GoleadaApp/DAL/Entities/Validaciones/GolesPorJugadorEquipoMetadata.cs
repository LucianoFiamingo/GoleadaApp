using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.EDMX
{
    internal class GolesPorJugadorEquipoMetadata
    {
        [Required(ErrorMessage = "Requiere un id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe insertar una cantidad de goles")]
        [Range(1, 3000, ErrorMessage = "Debe ingresar un número entre 1 y 1000")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe insertar el nombre del Equipo")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder los 200 caracteres")]
        public string Equipo { get; set; }

        [Required(ErrorMessage = "Debe elegir un jugador")]
        public int IdJugador { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}