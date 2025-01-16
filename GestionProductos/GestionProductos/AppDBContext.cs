using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Text.Json.Serialization;

namespace GestionProductos
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options) { 
        
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }

    public class Producto
    {
        public required int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        [JsonRequired] public decimal Precio { get; set; }
        public int? Stock { get; set; }
        public int? CategoriaId { get; set; }
    }

    public class Categoria
    { 
        public required int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
