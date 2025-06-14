using Microsoft.AspNetCore.Mvc;
using App_Cobranza.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Data.SqlClient; // ✔️ Para SQL Server
using System.Data;

namespace App_Cobranza.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(string usuario, string contrasena)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                ModelState.AddModelError("", "Debe ingresar usuario y contraseña");
                return View();
            }

            var usuarioValido = await AutenticarEnSqlServer(usuario, contrasena);

            if (usuarioValido != null)
            {
                var nombreCompleto = $"{usuarioValido.primer_nombre} {usuarioValido.apellido_paterno}";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim("NombreCompleto", nombreCompleto),
                 
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true
                    });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Credenciales inválidas");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }


        private async Task<usuarios> AutenticarEnSqlServer(string usuario, string contrasena)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=telcomx_;User Id=telcomx_;Password=sol_arena_mar;");


            var query = @"SELECT id_usuario, primer_nombre, segundo_nombre,
                                 apellido_paterno, apellido_materno, tipo_usuario
                          FROM usuarios 
                          WHERE usuario = @usuario AND contrasena = @contrasena";

            await connection.OpenAsync();

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@contrasena", contrasena); // ⚠️ Usa hashing en producción

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new usuarios
                {
                    id_usuario = reader.GetInt32(reader.GetOrdinal("id_usuario")),
                    primer_nombre = reader.GetString(reader.GetOrdinal("primer_nombre")),
                    segundo_nombre = reader.IsDBNull(reader.GetOrdinal("segundo_nombre")) ? null : reader.GetString(reader.GetOrdinal("segundo_nombre")),
                    apellido_paterno = reader.GetString(reader.GetOrdinal("apellido_paterno")),
                    apellido_materno = reader.IsDBNull(reader.GetOrdinal("apellido_materno")) ? null : reader.GetString(reader.GetOrdinal("apellido_materno")),
                    usuario = usuario,
                    tipo_usuario = reader.GetString(reader.GetOrdinal("tipo_usuario"))
                };
            }

            return null;
        }
    }
}



