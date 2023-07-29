using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class materiaPrimaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public materiaPrimaController(AppDbContext context)
        {
            _context = context;
        }

		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.materiaPrima.ToList());
			}catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpGet("{id}", Name = "MateriaPrima")]
        public ActionResult Get(int id)
		{
            try
            {
                var materiaPrima = _context.materiaPrima.FirstOrDefault(x => x.Id == id);

                if (materiaPrima == null)
                {
                    return NotFound();
                }

                return Ok(materiaPrima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpPost]
		public ActionResult<materiaPrima> Post([FromBody] materiaPrima materiaPrima)
		{
            try
            {
                _context.materiaPrima.Add(materiaPrima);
                _context.SaveChanges();

                return CreatedAtRoute("MateriaPrima", new { id = materiaPrima.Id }, materiaPrima);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] materiaPrima materiaPrima)
		{
            try
            {
                if (materiaPrima.Id == id)
                {
                    _context.Entry(materiaPrima).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("MateriaPrima", new { id = materiaPrima.Id }, materiaPrima);
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
                var materiaPrima = _context.materiaPrima.FirstOrDefault(p => p.Id == id);

                if (materiaPrima == null)
                {
                    return NotFound();
                }

                _context.materiaPrima.Remove(materiaPrima);
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
