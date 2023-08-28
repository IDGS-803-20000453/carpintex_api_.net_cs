using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class compras
    {

        [Key]
        public int Id { get; set; }
        public Double Cantidad { get; set; }
        public Double Total { get; set; }
        public DateTime Fecha { get; set; }
        public int MateriaPrima_id { get; set; }
        public int Proveedor_id { get; set; }

    }
}
