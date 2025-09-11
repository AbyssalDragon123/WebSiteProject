namespace QuickMarket.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoriaPadre { get; set; }
    }
}
