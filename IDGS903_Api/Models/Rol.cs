using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class Rol
	{
		[Key]
		public int Id { get; set; }
		public string ? Name { get; set; }
		public string ? Description { get; set; }

	}
}
