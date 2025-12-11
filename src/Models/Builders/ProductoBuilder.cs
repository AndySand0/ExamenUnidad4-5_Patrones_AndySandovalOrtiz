public class ProductoBuilder
{
    private IProducto _producto;

    public ProductoBuilder CrearBase(int id, string nombre, decimal precio)
    {
        _producto = new Producto(id, nombre, precio);
        return this;
    }

    public ProductoBuilder ConCategoria(string categoria)
    {
        _producto = new CategoriaDecorator(_producto, categoria);
        return this;
    }

    public ProductoBuilder ConMarca(string marca)
    {
        _producto = new MarcaDecorator(_producto, marca);
        return this;
    }

    public ProductoBuilder ConEtiqueta(string clave, string valor)
    {
        _producto = new EtiquetaDecorator(_producto, clave, valor);
        return this;
    }

    public IProducto Construir() => _producto;
}
