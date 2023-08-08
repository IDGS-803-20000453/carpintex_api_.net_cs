using IDGS903_Api.Context;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				var frontendURL = Configuration.GetValue
				<string>("frontend_url");
				options.AddDefaultPolicy(builder =>
				{
					builder.WithOrigins("http://192.168.137.1:4200").
					AllowAnyMethod().AllowAnyHeader();

				});
			});
			services.AddControllers();
			services.AddDbContext<AppDbContext>(
				options =>
				options.UseSqlServer(Configuration.GetConnectionString("conexion"))

				);

			services.AddHttpClient("Insecure")
			.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
				{
					return true; // Aceptar todos los certificados, incluso los no válidos.
				}
			});
		}

		public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
		{
			app.UseHttpsRedirection();
		}
	}
}