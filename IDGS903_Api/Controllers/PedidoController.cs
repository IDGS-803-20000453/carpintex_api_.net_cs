using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class PedidoController : Controller
	{
		private readonly AppDbContext _context;
		public PedidoController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.pedido.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpPost]
		public ActionResult<Pedido> Post([FromBody] Pedido pedido)
		{
			try
			{
				_context.pedido.Add(pedido);
				_context.SaveChanges();
				return Ok("Compra agregada correctamente");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet("{id}", Name = "Pedido")]
		public ActionResult Get(int id)
		{
			try
			{
				var result = (from pedido in _context.pedido
							  join producto in _context.producto on pedido.Producto_id equals producto.Id
							  where pedido.User_id == id
							  select new
							  {
								  Pedido = pedido,
								  Producto = producto
							  }).ToList();

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult ActualizarEstatus(int id, [FromBody] int nuevoEstatus)
		{
			try
			{
				var pedido = _context.pedido.FirstOrDefault(x => x.Id == id);

				if (pedido == null)
				{
					return NotFound(); // O BadRequest, dependiendo de tu lógica
				}

				// Actualiza el estado del pedido con el nuevo valor
				pedido.EstatusPedido = nuevoEstatus;

				_context.SaveChanges();

				return CreatedAtRoute("Producto", new { id = pedido.Id }, pedido);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message); // Asegúrate de manejar las excepciones adecuadamente
			}
		}




	}
}


