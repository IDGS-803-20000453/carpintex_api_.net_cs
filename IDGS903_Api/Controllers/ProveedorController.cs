using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IDGS903_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProveedorController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ProveedorController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.proveedor.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}", Name = "Proveedor")]
		public ActionResult Get(int id)
		{
			try
			{
				var proveedor = _context.proveedor.FirstOrDefault(x => x.Id == id);

				if (proveedor == null)
				{
					return NotFound();
				}

				return Ok(proveedor);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public ActionResult<proveedor> Post([FromBody] proveedor proveedor)
		{
			try
			{
				_context.proveedor.Add(proveedor);
				_context.SaveChanges();

				return CreatedAtRoute("Proveedor", new { id = proveedor.Id }, proveedor);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] proveedor proveedor)
		{
			try
			{
				if (proveedor.Id == id)
				{
					_context.Entry(proveedor).State = EntityState.Modified;
					_context.SaveChanges();

					return CreatedAtRoute("Proveedor", new { id = proveedor.Id }, proveedor);
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
				var proveedor = _context.proveedor.FirstOrDefault(p => p.Id == id);

				if (proveedor == null)
				{
					return NotFound();
				}

				_context.proveedor.Remove(proveedor);
				_context.SaveChanges();

				return Ok(id);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
