using IDGS903_Api.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalUsuarioComprasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TotalUsuarioComprasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.TablaTotalUsuariosCompras.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{mes}")]
        public ActionResult Get(int mes)
        {
            try
            {

                var UsuariosCompras = _context.TablaTotalUsuariosCompras.FromSqlRaw("SELECT * FROM TablaTotalUsuariosCompras where mes=" + mes+"").ToList();

                
                return Ok(UsuariosCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Top3")]
        public ActionResult GetTop()
        {
            try
            {

                var UsuariosComprasTop = _context.TablaTotalUsuariosCompras.FromSqlRaw("SELECT TOP 3 * FROM TablaTotalUsuariosCompras ORDER BY Totalprecio DESC").ToList();


                return Ok(UsuariosComprasTop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}