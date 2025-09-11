namespace QuickMarket.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public required string UsuarioNombre { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Rol { get; set; }
        public required string Estado { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpira { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
    }
}
