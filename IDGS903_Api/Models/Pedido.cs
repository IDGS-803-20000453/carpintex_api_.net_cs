using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class Pedido
	{
		[Key]
		public int Id { get; set; }
		public Double Cantidad { get; set; }
		public Double Totalprecio { get; set; }
		public int EstatusPedido { get; set; }
		public int Producto_id { get; set; }
		public int User_id { get; set; }
		public DateTime? FechaRealizado { get; set; }

	}
}
