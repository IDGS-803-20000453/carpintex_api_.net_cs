using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.producto.ToList());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "Producto")]
        public ActionResult Get(int id)
        {
            try
            {

                var producto = _context.producto.FirstOrDefault(x => x.Id == id);

                if(producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            try
            {
                _context.producto.Add(producto);
                _context.SaveChanges();
                return CreatedAtRoute("Producto", new { id = producto.Id }, producto);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (producto.Id == id)
                {
                    _context.Entry(producto).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("Producto", new { id = producto.Id }, producto);
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
                var producto = _context.producto.FirstOrDefault(p => p.Id == id);

                if (producto == null)
                {
                    return NotFound();
                }

                _context.producto.Remove(producto);
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
