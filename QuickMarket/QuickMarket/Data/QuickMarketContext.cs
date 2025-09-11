using Microsoft.EntityFrameworkCore;
using QuickMarket.Models;

namespace QuickMarket
{
    public class QuickMarketContext : DbContext
    {
        public QuickMarketContext(DbContextOptions<QuickMarketContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USUARIOS
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
                entity.Property(e => e.UsuarioNombre).HasColumnName("USUARIO");
                entity.Property(e => e.Email).HasColumnName("EMAIL");
                entity.Property(e => e.Password).HasColumnName("PASSWORD");
                entity.Property(e => e.Rol).HasColumnName("ROL");
                entity.Property(e => e.Estado).HasColumnName("ESTADO");
                entity.Property(e => e.ResetToken).HasColumnName("RESET_TOKEN");
                entity.Property(e => e.ResetTokenExpira).HasColumnName("RESET_TOKEN_EXPIRA");
                entity.Property(e => e.CreadoEn).HasColumnName("CREADO_EN");
                entity.Property(e => e.ActualizadoEn).HasColumnName("ACTUALIZADO_EN");
            });

            // CLIENTES
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
                entity.Property(e => e.Direccion).HasColumnName("DIRECCION");
                entity.Property(e => e.Departamento).HasColumnName("DEPARTAMENTO");
                entity.Property(e => e.Municipio).HasColumnName("MUNICIPIO");
                entity.Property(e => e.Referencia).HasColumnName("REFERENCIA");
            });

            // CATEGORIAS
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("CATEGORIAS");
                entity.HasKey(e => e.IdCategoria);
                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
                entity.Property(e => e.IdCategoriaPadre).HasColumnName("ID_CATEGORIA_PADRE");
            });

            // PRODUCTOS
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTOS");
                entity.HasKey(e => e.IdProducto);
                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
                entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
                entity.Property(e => e.CodigoBarras).HasColumnName("CODIGO_BARRAS");
                entity.Property(e => e.PrecioUnitario).HasColumnName("PRECIO_UNITARIO");
                entity.Property(e => e.Stock).HasColumnName("STOCK");
                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            });

            // VENTAS
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("VENTAS");
                entity.HasKey(e => e.IdVenta);
                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
                entity.Property(e => e.Fecha).HasColumnName("FECHA");
                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
                entity.Property(e => e.TotalBruto).HasColumnName("TOTAL_BRUTO");
                entity.Property(e => e.TotalImpuestos).HasColumnName("TOTAL_IMPUESTOS");
                entity.Property(e => e.TotalNeto).HasColumnName("TOTAL_NETO");
                entity.Property(e => e.Estado).HasColumnName("ESTADO");
                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            });

            // DETALLE_VENTAS
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("DETALLE_VENTAS");
                entity.HasKey(e => e.IdDetalle);
                entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");
                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");
                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
                entity.Property(e => e.PrecioUnitario).HasColumnName("PRECIO_UNITARIO");
            });
        }
    }
}
