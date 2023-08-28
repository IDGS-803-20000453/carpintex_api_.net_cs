using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class TablaTotalUsuarios
	{
		[Key]
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public int NumeroCompras { get; set; }
		public decimal TotalPrecio { get; set; }
		public int Mes { get; set; }
		public int Anio { get; set; }
	}
}
