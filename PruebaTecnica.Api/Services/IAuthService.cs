namespace PruebaTecnica.Api.Services
{
    //Interfaz que define los métodos para el servicio de autenticació
    public interface IAuthService
    {
        // Metodo asincronico para autenticar a un usuario con username y password.
        Task<(string jwt, string externalToken)> LoginAsync(string username, string password);
        //Metodo asincronico para obtener la lista de usuarios desde una API externa.
        Task<string> GetUsersAsync();
    }
}
