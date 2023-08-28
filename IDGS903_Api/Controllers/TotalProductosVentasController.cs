using IDGS903_Api.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalProductosVentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TotalProductosVentasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.TablaTotalProductosVenta.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{mes}")]
        public ActionResult Get(int mes) {
            try
            {

                var ProductosVentas = _context.TablaTotalProductosVenta.FromSqlRaw("SELECT * FROM TablaTotalProductosVenta where mes=" + mes + "").ToList();


                return Ok(ProductosVentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
