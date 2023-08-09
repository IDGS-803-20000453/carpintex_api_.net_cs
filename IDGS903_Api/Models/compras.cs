using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class compras
    {

        [Key]
        public int Id { get; set; }
        public float Cantidad { get; set; }
        public float Total { get; set; }
        public DateTime Fecha { get; set; }
        public int MateriaPrima_id { get; set; }
        public int Proveedor_id { get; set; }

    }
}
