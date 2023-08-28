using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Gasto_Materia_PrimaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Gasto_Materia_PrimaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.gasto_Materia_Prima.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<Gasto_Materia_PrimaController>/5
        [HttpGet("{id}", Name = "gastoMateriPrima")]
        public ActionResult Get(int id)
        {
            try
            {

                var gastoMateriaPrima = _context.gasto_Materia_Prima.FirstOrDefault(x => x.Id == id);

                if (gastoMateriaPrima == null)
                {
                    return NotFound();
                }
                return Ok(gastoMateriaPrima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Gasto_Materia_PrimaController>
        [HttpPost]
        public ActionResult<Gasto_Materia_Prima> Post([FromBody] Gasto_Materia_Prima gasto_Materia_Prima)
        {

            try
            {
                _context.gasto_Materia_Prima.Add(gasto_Materia_Prima);
                _context.SaveChanges();
                return CreatedAtRoute("Gasto_Materia_Prima", new { id = gasto_Materia_Prima.Id }, gasto_Materia_Prima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<Gasto_Materia_PrimaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gasto_Materia_Prima gasto_Materia_Prima)
        {
            try
            {
                if (gasto_Materia_Prima.Id == id)
                {
                    _context.Entry(gasto_Materia_Prima).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("Gasto_Materia_Prima", new { id = gasto_Materia_Prima.Id }, gasto_Materia_Prima);
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

        // DELETE api/<Gasto_Materia_PrimaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gasto_Materia_Prima = _context.gasto_Materia_Prima.FirstOrDefault(p => p.Id == id);

                if (gasto_Materia_Prima == null)
                {
                    return NotFound();
                }

                _context.gasto_Materia_Prima.Remove(gasto_Materia_Prima);
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