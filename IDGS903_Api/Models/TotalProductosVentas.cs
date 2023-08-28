using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class TotalProductosVentas
    {
        [Key]
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public Double CantidadTotal { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
    }
}
