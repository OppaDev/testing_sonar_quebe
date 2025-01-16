using GestionProductos;

namespace TestProjectGestionProductos
{
    public class ProductControllerTest
    {
        [Fact]
        public void Test1()
        {
            //Configurar el casos de prueba
            var producto = new Producto
            {
                Id = 5,
                Nombre = "Producto 1",
                Descripcion = "Descripcion del producto 1",
                Precio = 100,
            };

            //validar el caso de prueba
            Assert.True(producto.Precio >= 0, "El precio no puede ser negativo");

        }
    }
}
