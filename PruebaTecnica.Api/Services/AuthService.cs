using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.Models;
using System.Text;

namespace PruebaTecnica.Api.Services
{
    // Servicio autenticación y la gestión de tokens
    public class AuthService : IAuthService
    {
        // Servicio para generar tokens JWT 
        private readonly JwtService _tokenService;
        // Cliente HTTP API externa
        private readonly HttpClient _httpClient;
        // Contexto  base de datos local
        private readonly AppDbContext _context;

        // Constructor 
        public AuthService(JwtService tokenService, IHttpClientFactory httpClientFactory, AppDbContext context)
        {
            _tokenService = tokenService;
            _httpClient = httpClientFactory.CreateClient();
            // base URL para las solicitudes HTTP a la API externa
            _httpClient.BaseAddress = new Uri("https://apps.derechodeautor.gov.co/dummyjson/api/");
            _context = context;
        }
        // Método para realizar el login
        public async Task<(string jwt, string externalToken)> LoginAsync(string username, string password)
        {
            // payload con usuario y contraseña en formato JSON
            var payload = new { username, password };
            var json = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            // petición POST a la API externa para autenticar
            var response = await _httpClient.PostAsync("users/login", json);

            // Si la autenticación falla,excepción de acceso no autorizado
            if (!response.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");

            // Lectura respuesta JSON
            var result = await response.Content.ReadAsStringAsync();
            using var doc = System.Text.Json.JsonDocument.Parse(result);

            //  token externo de la respuesta
            var externalToken = doc.RootElement.TryGetProperty("token", out var tokenElement)
                ? tokenElement.GetString()
                : "";
            // token JWT para la aplicación
            var jwt = _tokenService.GenerateToken(username);

            // log en MySQL
            var loginLog = new LoginLog
            {
                Username = username,
                LoginTime = DateTime.UtcNow,
                AccessToken = externalToken ?? ""
            };
            // log al contexto y save cambios mysql
            _context.LoginLogs.Add(loginLog);
            await _context.SaveChangesAsync();

            // return tokens: JWT interno y token externo de la API
            return (jwt, externalToken ?? "");
        }
        // Método para obtener lista de usuarios Api Externa
        public async Task<string> GetUsersAsync()
        {
            // petición GET a la API externa
            var response = await _httpClient.GetAsync("users");
            // Si hay un error excepción
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al consultar usuarios externos.");
            // return contenido JSON como string
            return await response.Content.ReadAsStringAsync();
        }

    }
}
