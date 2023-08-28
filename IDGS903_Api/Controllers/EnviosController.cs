using IDGS903_Api.Context;
using Microsoft.AspNetCore.Mvc;

namespace IDGS903_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnviosController : ControllerBase
	{

		private readonly AppDbContext _context;

		public EnviosController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.envios.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}", Name = "Envios")]
		public IActionResult ActualizarEstatus(int id, [FromBody] int nuevoEstatus)
		{
			try
			{
				var envios = _context.envios.FirstOrDefault(x => x.Id == id);

				if (envios == null)
				{
					return NotFound(); // O BadRequest, dependiendo de tu lógica
				}

				// Actualiza el estado del pedido con el nuevo valor
				envios.Estatus = nuevoEstatus;

				_context.SaveChanges();

				return CreatedAtRoute("Envios", new { id = envios.Id }, envios);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message); // Asegúrate de manejar las excepciones adecuadamente
			}
		}
	}
}
