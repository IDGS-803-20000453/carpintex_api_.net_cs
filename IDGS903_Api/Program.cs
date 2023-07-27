using IDGS903_Api;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);  // Implementado
startup.ConfigureServices(builder.Services);  // Implementado

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

startup.Configure(app, app.Lifetime);  // Implementado

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(); // Implementado
app.Run();