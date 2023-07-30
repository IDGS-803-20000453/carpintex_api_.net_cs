using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {


        private readonly AppDbContext _context;

        public ComprasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.compras.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ComprasController>/5
        [HttpGet("{id}", Name ="Compras")]
        public ActionResult Get(int id)
        {
            try
            {

                var compras = _context.compras.FirstOrDefault(x => x.Id == id);

                if (compras == null)
                {
                    return NotFound();
                }
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComprasController>
        [HttpPost]
        public ActionResult<compras> Post([FromBody] compras compras)
        {
            try
            {
                _context.compras.Add(compras);
                _context.SaveChanges();
                return CreatedAtRoute("Compras", new { id = compras.Id }, compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComprasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] compras compras)
        {
            try
            {
                if (compras.Id == id)
                {
                    _context.Entry(compras).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("Compras", new { id = compras.Id }, compras);
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

        // DELETE api/<ComprasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var compras = _context.compras.FirstOrDefault(p => p.Id == id);

                if (compras == null)
                {
                    return NotFound();
                }

                _context.compras.Remove(compras);
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
