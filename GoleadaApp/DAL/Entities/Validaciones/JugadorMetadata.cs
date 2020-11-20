using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.EDMX
{
    internal class JugadorMetadata
    {
        [Required (ErrorMessage = "Requiere un id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength (80, ErrorMessage = "El nombre no puede exceder los 80 caracteres")]
        public string Nombre { get; set; }
    }
}