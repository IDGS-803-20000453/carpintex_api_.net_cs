using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class TablaTotalPedidos
	{
		[Key]
		public int Id { get; set; }
		public int CantidadTotal { get; set; }
		public decimal TotalPrecio { get; set; }
		public int Mes { get; set; }
		public int Anio { get; set; }
	}
}
