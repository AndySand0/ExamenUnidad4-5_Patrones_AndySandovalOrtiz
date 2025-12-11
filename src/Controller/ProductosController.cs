public class ProductosController
{
    private readonly GestorProductosFacade _gestor = new();

    public IProducto CrearProducto(int id, string nombre, decimal precio,
                                   string categoria, string marca)
        => _gestor.CrearProducto(id, nombre, precio, categoria, marca);

    public void AgregarCategoria(int id, string categoria) => _gestor.AgregarCategoria(id, categoria);
    public void AgregarMarca(int id, string marca) => _gestor.AgregarMarca(id, marca);
    public void AgregarEtiqueta(int id, string clave, string valor) => _gestor.AgregarEtiqueta(id, clave, valor);

    public void Deshacer() => _gestor.Deshacer();

    public IProducto ObtenerProducto(int id) => _gestor.ObtenerProducto(id);
    public IEnumerable<IProducto> ListarProductos() => _gestor.ListarProductos();
}
