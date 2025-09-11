namespace QuickMarket.Models
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
