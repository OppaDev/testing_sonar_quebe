using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public ProductosController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //obtener todos los productos
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _dbContext.Productos.ToListAsync());
        }
        //obtener un producto
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var producto = await _dbContext.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }
        //crear
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Producto producto)
        {
            if (producto.Precio < 0) return BadRequest("El precio es negativo");
            _dbContext.Productos.Add(producto);
            await _dbContext.SaveChangesAsync();
            return Ok(producto);
        }
        //actualizar un producto
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Producto producto)
        {
            _dbContext.Entry(producto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok(producto);
        }

        //eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var producto = await _dbContext.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _dbContext.Productos.Remove(producto);
            await _dbContext.SaveChangesAsync();
            return Ok(producto);
        }
    }
}
