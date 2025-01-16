using GestionProductos;

namespace TestProjectGestionProductos
{
    public class CategoriesControllerTest
    {
        [Fact]
        public void Test1()
        {
            //Configurar el casos de prueba
            var categoria = new Categoria
            {
                Id = 5,
                Nombre = "Categoria 1",
                Descripcion = "Descripcion de la categoria 1",
            };
            //validar el caso de prueba
            Assert.True(categoria.Id >= 0, "El Id no puede ser negativo");
        }
    }
}
