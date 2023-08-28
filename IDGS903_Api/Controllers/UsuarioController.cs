using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace IDGS903_Api.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : Controller
	{
		private readonly AppDbContext _context;
		public UsuarioController(AppDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public ActionResult Get()
		{
			try
			{
				return Ok(_context.usuario.ToList());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet("{id}", Name = "Usuario")]
		public ActionResult Get(int id)
		{
			try
			{
				var usuario = _context.usuario.FirstOrDefault(x => x.Id == id);
				if (usuario == null)
				{
					return NotFound();
				}
				return Ok(usuario);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            try
            {
                string hashedPassword = HashPassword(usuario.PasswordUsuario);
                usuario.PasswordUsuario = hashedPassword;

                _context.usuario.Add(usuario);
                _context.SaveChanges();
                return new CreatedAtRouteResult("Usuario", new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        [HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Usuario usuario)
		{
			try
			{
				if (usuario.Id == id)
				{
					_context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					_context.SaveChanges();
					return Ok();
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
				var usuario = _context.usuario.FirstOrDefault(x => x.Id == id);
				if (usuario != null)
				{
					_context.usuario.Remove(usuario);
					_context.SaveChanges();
					return Ok(id);
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
		[HttpGet("login/{email}")]
		public ActionResult Login(string email, string password)
		{
			try
			{
				var usuario = _context.usuario.FirstOrDefault(x => x.Email == email);
				if (usuario == null)
				{
					return NotFound("correo no encontrado");
				}
				if (!VerificarContraseña(password, usuario.PasswordUsuario))
				{
					return Unauthorized("contraseña incorrecta"); // Contraseña incorrecta
				}

				return Ok(usuario);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private bool VerificarContraseña(string contraseñaIngresada, string contraseñaAlmacenada)
		{
			// Aquí debes implementar la lógica para verificar si la contraseña ingresada coincide con la contraseña almacenada.
			// Utiliza algoritmos de hash y salting para mayor seguridad.
			// No almacenes contraseñas en texto claro.
			// Devuelve true si la contraseña coincide, de lo contrario, false.
			// Puedes usar bibliotecas como BCrypt.Net para realizar esta verificación.
			// Ejemplo: return BCrypt.Net.BCrypt.Verify(contraseñaIngresada, contraseñaAlmacenada);
			return contraseñaIngresada == contraseñaAlmacenada; // Esto es solo un ejemplo simple, NO es seguro en producción.
		}

	}
}