using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class Gasto_Materia_Prima
    {
        [Key]
        public int Id { get; set; }
        public Double Cantidad { get; set; }
        public Double Costo { get; set; }
        public int MateriaPrima_id { get; set; }
        public int Producto_id { get; set; }
    }
}
