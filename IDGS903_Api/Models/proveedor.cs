﻿using System.ComponentModel.DataAnnotations;

namespace IDGS903_Api.Models
{
	public class proveedor
	{
		[Key]
		public int Id { get; set; }
		public string ? Nombre { get; set; }
		public string ? Direccion { get; set; }
		public string ? Telefono { get; set; }
		public string ? Email { get; set; }
	}
}
