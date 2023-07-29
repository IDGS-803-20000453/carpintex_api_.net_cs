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
        public float Altura { get; set; }
        public float Ancho { get; set; }
        public float Largo { get; set; }
        public String? Imagen { get; set; }
        public float Total { get; set; }
        public int Estatus { get; set; }
    }
}
