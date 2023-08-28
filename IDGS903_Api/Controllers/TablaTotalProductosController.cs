using IDGS903_Api.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq; // No olvides agregar este using para utilizar la función 'Where'

namespace IDGS903_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TablaTotalProductosController : ControllerBase
	{
		private readonly AppDbContext2 _context; // Asegúrate de usar el contexto correcto para esta conexión

		public TablaTotalProductosController(AppDbContext2 context)
		{
			_context = context;
		}

		// Endpoint para obtener todos los registros sin filtrar por mes
		[HttpGet]
		public ActionResult GetAll()
		{
			try
			{
				var productos = _context.TablaTotalProductos.ToList();
				return Ok(productos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// Endpoint para obtener registros filtrados por mes
		[HttpGet("{mes}")]
		public ActionResult Get(int mes)
		{
			try
			{
				if (mes < 5 || mes > 8)
				{
					return BadRequest("Mes no válido");
				}

				var productos = _context.TablaTotalProductos.Where(p => p.Mes == mes).ToList();
				return Ok(productos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
