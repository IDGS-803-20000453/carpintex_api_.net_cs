using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMateriaPrimaController : Controller
    {
        private readonly AppDbContext _context;

        public TipoMateriaPrimaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.tipoMateriaPrima.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "TipoMateria")]
        public ActionResult Get(int id)
        {
            try
            {

                var tipoMateriaPrima = _context.tipoMateriaPrima.FirstOrDefault(x => x.Id == id);

                if (tipoMateriaPrima == null)
                {
                    return NotFound();
                }
                return Ok(tipoMateriaPrima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<tipoMateriaPrima> Post([FromBody] tipoMateriaPrima tipoMateriaPrima)
        {
            try
            {
                _context.tipoMateriaPrima.Add(tipoMateriaPrima);
                _context.SaveChanges();
                return CreatedAtRoute("TipoMateriaPrima", new { id = tipoMateriaPrima.Id }, tipoMateriaPrima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] tipoMateriaPrima tipoMateriaPrima)
        {
            try
            {
                if (tipoMateriaPrima.Id == id)
                {
                    _context.Entry(tipoMateriaPrima).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("TipoMateriaPrima", new { id = tipoMateriaPrima.Id }, tipoMateriaPrima);
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
                var tipoMateriaPrima = _context.tipoMateriaPrima.FirstOrDefault(p => p.Id == id);

                if (tipoMateriaPrima == null)
                {
                    return NotFound();
                }

                _context.tipoMateriaPrima.Remove(tipoMateriaPrima);
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
