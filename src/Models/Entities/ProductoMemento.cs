public class ProductoMemento
{
    public IProducto Estado { get; }

    public ProductoMemento(IProducto estado)
    {
        Estado = estado;
    }
}
