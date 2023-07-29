using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class materiaPrima
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public float Costo { get; set; }
        public float Stock { get; set; }
        public int TipoMateriaPrima_id { get; set; }
        public int Proveedor_id { get; set; }

    
    
    }
}
