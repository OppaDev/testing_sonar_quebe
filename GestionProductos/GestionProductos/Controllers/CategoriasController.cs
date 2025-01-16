using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public CategoriasController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Obtener todas las categorias
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _dbContext.Categorias.ToListAsync());
        }
        //Obtener una categoria
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }
        //Crear una categoria
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Categoria categoria)
        {
            if (categoria.Nombre == null) return BadRequest("El nombre es requerido");
            _dbContext.Categorias.Add(categoria);
            await _dbContext.SaveChangesAsync();
            return Ok(categoria);
        }
        //Actualizar una categoria
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Categoria categoria)
        {
            _dbContext.Entry(categoria).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok(categoria);
        }
        //Eliminar una categoria
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();
            _dbContext.Categorias.Remove(categoria);
            await _dbContext.SaveChangesAsync();
            return Ok(categoria);
        }

    }
}
