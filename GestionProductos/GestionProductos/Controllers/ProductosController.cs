using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly AppDBContext _dbContext;
        public string password;

        public ProductosController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _dbContext.Productos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Producto producto)
        {
            if (producto.Precio < 0) return BadRequest("El precio es negativo");
            _dbContext.Productos.Add(producto);
            await _dbContext.SaveChangesAsync();
            return Ok(producto);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
