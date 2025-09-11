namespace QuickMarket.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdCliente { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalNeto { get; set; }
        public required string Estado { get; set; }
        public int? IdUsuario { get; set; }
    }
}
