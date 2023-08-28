using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class Envios
	{
		[Key]
		public int Id { get; set; }
		public int? IdPedido { get; set; }
		public DateTime? FechaEnvio { get; set; }
		public DateTime FechaEntrega { get; set; }
		public string? ProveedorEnvio { get; set; }
		public string? NoSeguimiento { get; set; }
		public int? Estatus { get; set; }


	}
}
