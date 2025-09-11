namespace QuickMarket.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public string? Referencia { get; set; }
    }
}
