using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
    public class ObtencionGasto
    {
        [Key]
        public int materiaPrima_Id { set; get; }
        public Double Cantidad { set; get; }

    }
}
