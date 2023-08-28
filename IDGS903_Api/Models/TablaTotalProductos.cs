using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class TablaTotalProductos
	{
		[Key]
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public int CantidadTotal { get; set; }
		public decimal PrecioTotal { get; set; }
		public int Mes { get; set; }
		public int Anio { get; set; }
	}
}
