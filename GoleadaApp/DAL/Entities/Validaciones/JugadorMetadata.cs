using System.ComponentModel.DataAnnotations;

namespace DAL
{
    internal class JugadorMetadata
    {
        [Required (ErrorMessage = "Requiere un id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Requiere un nombre")]
        [StringLength (200, ErrorMessage = "El nombre no puede exceder los 200 caracteres")]
        public string Nombre { get; set; }
    }
}