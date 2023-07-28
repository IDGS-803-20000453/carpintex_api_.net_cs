using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class EmpleadoController : Controller
    {

        private readonly AppDbContext _context;

        public EmpleadoController(AppDbContext context) 
        { 
        
            _context = context;

        }


        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.empleado.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name ="Empleado")]
        public ActionResult Get(int id)
        {
            try
            {
                var empl = _context.empleado.FirstOrDefault(x => x.Id == id);

                return Ok(empl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult<empleado> Post([FromBody] empleado empleado)
        {
            try
            {
                _context.empleado.Add(empleado);
                _context.SaveChanges();

                return CreatedAtRoute("Empleado", new { id = empleado.Id }, empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]empleado empl) 
        {
            try
            {
                if (empl.Id == id)
                {
                    _context.Entry(empl).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("Empleado", new { id = empl.Id }, empl);
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
                var empl = _context.empleado.FirstOrDefault(empleado => empleado.Id == id);

                if (empl != null)
                {
                    _context.empleado.Remove(empl);
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
