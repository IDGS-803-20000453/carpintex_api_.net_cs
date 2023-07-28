using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class empleado
    {

        [Key]

        public int Id { get; set; }

        public string ? Nombre { get; set; }

		public DateTime Fecha_nacimiento { get; set; }

		public string ? Correo { get; set; }
    }
}
