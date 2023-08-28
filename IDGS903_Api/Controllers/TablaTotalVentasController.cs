using IDGS903_Api.Context;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IDGS903_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TablaTotalVentasController : ControllerBase
	{
		private readonly AppDbContext2 _context; // Asegúrate de usar el contexto correcto

		public TablaTotalVentasController(AppDbContext2 context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.TablaTotalVentas.ToList()); // Asume que tienes un DbSet llamado TablaTotalVentas en AppDbContext2
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
