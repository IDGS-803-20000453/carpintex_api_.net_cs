using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricacionProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FabricacionProductoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.fabricacionProducto.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*
        [HttpGet("getGAstoMateriaProducto")]
        public ActionResult Get2(int cantidadH)
        {
            try
            {

                var idProductoParam = new SqlParameter("@idproducto", 1);
                var gastoProductoList = _context.obtenerGasto.FromSqlRaw("EXEC obtenergastosmateria @idproducto", idProductoParam)
                .ToList();
                int resultado=0;

                foreach (var gastoMateriaVerificacion in gastoProductoList) {
                    var idMateriaParam = new SqlParameter("@idmateria", gastoMateriaVerificacion.materiaPrima_Id); // Suponiendo que tienes el valor de idMateria
                    var cantidadRestaParam = new SqlParameter("@cantidadrestar", gastoMateriaVerificacion.Cantidad*cantidadH); // Suponiendo que tienes el valor de cantidadResta
                    var resultadoParam = new SqlParameter("@resultado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    _context.Database.ExecuteSqlRaw("EXEC verificacionMateriaPrima @idmateria, @cantidadrestar, @resultado OUTPUT",
                        idMateriaParam, cantidadRestaParam, resultadoParam);

                    resultado += (int)resultadoParam.Value;

                }

                if (resultado < 1)
                {
                    foreach (var gastoProducto in gastoProductoList)
                    {
                        var idMateriaParam = new SqlParameter("@idmateria", gastoProducto.materiaPrima_Id);
                        var cantidadParam = new SqlParameter("@catidadresta", (gastoProducto.Cantidad * cantidadH));

                        _context.Database.ExecuteSqlRaw("EXEC restarmateria @idmateria, @catidadresta", idMateriaParam, cantidadParam);
                    }
                    return Ok("Producto agregado correctamente");
                }
                else
                {
                    return Ok("No se puede no se cuenta con la materia suficiente"+ resultado);
                }
                /* foreach (var gastoProducto in gastoProductoList)
                {
                    var idMateriaParam = new SqlParameter("@idmateria", gastoProducto.materiaPrima_Id);
                    var cantidadParam = new SqlParameter("@catidadresta", (gastoProducto.Cantidad * cantidadH));

                    _context.Database.ExecuteSqlRaw("EXEC restarmateria @idmateria, @catidadresta", idMateriaParam, cantidadParam);
                }

                //return Ok("Producto agregado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */



        [HttpGet("{id}", Name = "fabricacionProducto")]
        public ActionResult Get(int id)
        {
            try
            {

                var fabricacionProducto = _context.fabricacionProducto.FirstOrDefault(x => x.Id == id);

                if (fabricacionProducto == null)
                {
                    return NotFound();
                }
                return Ok(fabricacionProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST 
        [HttpPost]
        public ActionResult<fabricacionProducto> Post([FromBody] fabricacionProducto fabricacion)
        {

            try
            {
                var idProductoParam = new SqlParameter("@idproducto", fabricacion.Producto_Id);
                var gastoProductoList = _context.obtenerGasto.FromSqlRaw("EXEC obtenergastosmateria @idproducto", idProductoParam)
                .ToList();
                int resultado = 0;

                foreach (var gastoMateriaVerificacion in gastoProductoList)
                {
                    var idMateriaParam = new SqlParameter("@idmateria", gastoMateriaVerificacion.materiaPrima_Id); // Suponiendo que tienes el valor de idMateria
                    var cantidadRestaParam = new SqlParameter("@cantidadrestar", gastoMateriaVerificacion.Cantidad * fabricacion.Cantidad); // Suponiendo que tienes el valor de cantidadResta
                    var resultadoParam = new SqlParameter("@resultado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    _context.Database.ExecuteSqlRaw("EXEC verificacionMateriaPrima @idmateria, @cantidadrestar, @resultado OUTPUT",
                        idMateriaParam, cantidadRestaParam, resultadoParam);

                    resultado += (int)resultadoParam.Value;

                }

                if (resultado < 1)
                {
                    foreach (var gastoProducto in gastoProductoList)
                    {
                        var idMateriaParam = new SqlParameter("@idmateria", gastoProducto.materiaPrima_Id);
                        var cantidadParam = new SqlParameter("@catidadresta", (gastoProducto.Cantidad * fabricacion.Cantidad));

                        _context.Database.ExecuteSqlRaw("EXEC restarmateria @idmateria, @catidadresta", idMateriaParam, cantidadParam);
                    }
                    _context.fabricacionProducto.Add(fabricacion);
                    _context.SaveChanges();
                    return Ok(new { message = "Producto agregado correctamente" });
                }
                else
                {
                    return Ok(new { message = "No se puede no se cuenta con la materia suficiente" });
                }

                //return CreatedAtRoute("fabricacionProducto", new { id = fabricacion.Id }, fabricacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<fabricacion>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] fabricacionProducto fabricacion)
        {
            try
            {
                if (fabricacion.Id == id)
                {
                    _context.Entry(fabricacion).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("fabricacionProducto", new { id = fabricacion.Id }, fabricacion);
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

        // DELETE api/<fabricacion>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var fabricacion = _context.fabricacionProducto.FirstOrDefault(p => p.Id == id);

                if (fabricacion == null)
                {
                    return NotFound();
                }
                var idProductoParam = new SqlParameter("@idProducto", fabricacion.Producto_Id);
                var CantidadParam = new SqlParameter("@catidadSuma", fabricacion.Cantidad);

                _context.Database.ExecuteSqlRaw("EXEC AgregarFabricacionProducto @idProducto, @catidadSuma", idProductoParam, CantidadParam);

                _context.fabricacionProducto.Remove(fabricacion);
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