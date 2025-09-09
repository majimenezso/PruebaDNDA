using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Api.Services
{
    // Servicio encargado de generar tokens JWT para la autenticación de usuarios
    public class JwtService
    {
        // Configuración para obtener claves y parámetros del JWT
        private readonly IConfiguration _config;

        // Constructor q
        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        // Metodo que genera token para un usuario dado
        public string GenerateToken(string username)
        {
            //claims que contendrá el token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };
             // Oclave secreta para firmar el token desde la configuración
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            // firma del token usando HMAC-SHA256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // token JWT con issuer, audience, claims, expiración y credenciales de firma
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                // valido por 1 hora
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            // return Serializado  token a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
