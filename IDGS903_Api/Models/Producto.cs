using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class Producto
    {
        [Key] 
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Descripcion { get; set; }
        public int Stock { get; set; }
        public Double Altura { get; set; }
        public Double Ancho { get; set; }
        public Double Largo { get; set; }
        public String? Imagen { get; set; }
        public Double Total { get; set; }
        public int Estatus { get; set; }
    }
}
