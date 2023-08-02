using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace IDGS903_Api.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : Controller
	{
		private readonly AppDbContext _context;
		public UsuarioController (AppDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.usuario.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet("{id}", Name = "Usuario")]
		public ActionResult Get(int id)
		{
			try
			{
				var usuario = _context.usuario.FirstOrDefault(x => x.Id == id);
				if (usuario == null)
				{
					return NotFound();
				}
				return Ok(usuario);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		public ActionResult<Usuario> Post([FromBody] Usuario usuario)
		{
			try
			{
				_context.usuario.Add(usuario);
				_context.SaveChanges();
				return new CreatedAtRouteResult("Usuario", new { id = usuario.Id }, usuario);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Usuario usuario)
		{
			try
			{
				if (usuario.Id == id)
				{
					_context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					_context.SaveChanges();
					return Ok();
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			try
			{
				var usuario = _context.usuario.FirstOrDefault(x => x.Id == id);
				if (usuario != null)
				{
					_context.usuario.Remove(usuario);
					_context.SaveChanges();
					return Ok(id);
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
