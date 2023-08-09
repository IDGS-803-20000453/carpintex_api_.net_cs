using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class tipoMateriaPrima
    {
        [Key]
        public int Id { set; get; }
        public String? Tipo { set; get; }
        public String? UnidadMedida { set; get; }



    }
}
