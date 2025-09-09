using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Api.Models
{
    //tabla 'login_log' en la base de datos
    [Table("login_log")] 
    public class LoginLog
    {
        // propiedad llave primaria
        public int Id { get; set; }

        //propiedad username
        [Column("username")]
        public string Username { get; set; } = string.Empty;
         //prpiedad fecha y hora
        [Column("login_time")]
        public DateTime LoginTime { get; set; }
        // propiedad token generado
        [Column("access_token")]
        public string AccessToken { get; set; } = string.Empty;
    }
}
