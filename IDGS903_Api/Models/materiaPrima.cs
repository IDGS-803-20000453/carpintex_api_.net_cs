using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class materiaPrima
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Double Costo { get; set; }
        public Double Stock { get; set; }
        public int TipoMateriaPrima_id { get; set; }
        public int Proveedor_id { get; set; }

    
    
    }
}
