using IDGS903_Api.Context;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IDGS903_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TablaTotalUsuariosController : ControllerBase
	{
		private readonly AppDbContext2 _context; // Asegúrate de usar el contexto correcto

		public TablaTotalUsuariosController(AppDbContext2 context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.TablaTotalUsuarios.ToList()); // Asume que tienes un DbSet llamado TablaTotalUsuarios en AppDbContext2
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		// Nuevo método para obtener datos filtrados por mes
		[HttpGet("PorMes/{mes}")]
		public ActionResult GetPorMes(int mes)
		{
			try
			{
				var datosFiltrados = _context.TablaTotalUsuarios.Where(t => t.Mes == mes).ToList();
				return Ok(datosFiltrados);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}