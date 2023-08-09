using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class Usuario
	{
		[Key]
		public int Id { get; set; }
		public string ? Name { get; set; }
		public string ? Email { get; set; }
		public string ? Calle { get; set; }
		public string ? Codigopostal { get; set; }
		public string ? Estado { get; set; }
		public string ? Ciudad { get; set; }
		public string ? PasswordUsuario { get; set; }
		public Boolean ? Activo { get; set; }
		public int? Rol_id { get; set; }


	}
}
