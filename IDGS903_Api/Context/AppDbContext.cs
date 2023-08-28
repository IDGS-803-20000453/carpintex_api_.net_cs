using IDGS903_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 

        }

        public DbSet<empleado> empleado { get; set; }
        //public DbSet<empleados> empleados { get; set; }
        public DbSet<proveedor> proveedor { get; set; }

        public DbSet<tipoMateriaPrima> tipoMateriaPrima { get; set; }
        public DbSet<materiaPrima> materiaPrima { get; set; }
        public DbSet<Producto> producto { get; set; }
        public DbSet<Gasto_Materia_Prima> gasto_Materia_Prima {get; set;}
        public DbSet<compras> compras { get; set; }
        

        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Rol> rol { get; set; }
		public DbSet<Pedido> pedido { get; set; }
		public DbSet<Envios> envios { get; set; }
        public DbSet<ObtencionGasto> obtenerGasto { get; set; }

        public DbSet<fabricacionProducto> fabricacionProducto { get; set; }

        public DbSet<TotalProductosVentas> TablaTotalProductosVenta { get; set; }
        public DbSet<TotalUsuarioCompras> TablaTotalUsuariosCompras { get; set; }

    }
}
