using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        [HttpGet]
        [Route("verify/{idMateria}/{idProveedor}")]
        public ActionResult VerificarMateriaPrimaProveedor(int idMateria, int idProveedor)
        {
            var materiaPrima = _context.materiaPrima.FirstOrDefault(mp => mp.Id == idMateria && mp.Proveedor_id == idProveedor);

            if (materiaPrima != null)
            {
                var respuesta = new { costo=materiaPrima.Costo};
                return Ok(respuesta);
            }
            else
            {
                var respuesta = new { Mensaje = "La materia prima del proveedor no es válida." };
                return BadRequest(respuesta);
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

		[HttpGet("con-nombres")]
		public ActionResult GetComprasConNombres()
		{
			try
			{
				var comprasConNombres = _context.compras
					.Join(_context.materiaPrima,
						  c => c.MateriaPrima_id,
						  mp => mp.Id,
						  (c, mp) => new { Compra = c, NombreMateriaPrima = mp.Nombre })
					.Join(_context.proveedor,
						  temp => temp.Compra.Proveedor_id, // Corrección aquí
						  prov => prov.Id,
						  (temp, prov) => new { temp.Compra, temp.NombreMateriaPrima, NombreProveedor = prov.Nombre })
					.ToList();

				return Ok(comprasConNombres);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("proveedores")]
		public ActionResult GetProveedores()
		{
			try
			{
				var proveedores = _context.proveedor
					.Select(p => new { Id = p.Id, Nombre = p.Nombre })
					.Distinct()
					.ToList();

				return Ok(proveedores);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("materias-primas")]
		public ActionResult GetMateriasPrimas()
		{
			try
			{
				var materiasPrimas = _context.materiaPrima
					.Select(mp => new { Id = mp.Id, Nombre = mp.Nombre })
					.Distinct()
					.ToList();

				return Ok(materiasPrimas);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}




	}
}
