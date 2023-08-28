using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class fabricacionProducto
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Producto_Id { get; set; }

    }
}