using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class GruposController : Controller
    {

        private readonly AppDbContext _context;

        public GruposController(AppDbContext context) 
        { 
        
            _context = context;

        }


        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.empleados.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name ="Empleados")]
        public ActionResult Get(int id)
        {
            try
            {
                var alum = _context.empleados.FirstOrDefault(x => x.Id == id);

                return Ok(alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult<empleados> Post([FromBody] empleados empleados)
        {
            try
            {
                _context.empleados.Add(empleados);
                _context.SaveChanges();

                return CreatedAtRoute("Empleados", new { id = empleados.Id }, empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]empleados alum) 
        {
            try
            {
                if (alum.Id == id)
                {
                    _context.Entry(alum).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("Empleados", new { id = alum.Id }, alum);
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
                var alum = _context.empleados.FirstOrDefault(empleados => empleados.Id == id);

                if (alum != null)
                {
                    _context.empleados.Remove(alum);
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
