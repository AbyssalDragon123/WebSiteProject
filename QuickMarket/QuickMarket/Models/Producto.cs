namespace QuickMarket.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public required string Nombre { get; set; }
        public string? CodigoBarras { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Stock { get; set; }
        public int? IdCategoria { get; set; }
    }
}
