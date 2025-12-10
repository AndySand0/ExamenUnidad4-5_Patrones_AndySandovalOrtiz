public abstract class ProductoDecorator : IProducto
{
    protected IProducto _producto;

    protected ProductoDecorator(IProducto producto)
    {
        _producto = producto;
    }

    public virtual int Id => _producto.Id;
    public virtual string Nombre => _producto.Nombre;
    public virtual decimal Precio => _producto.Precio;
    public virtual string ObtenerDescripcion() => _producto.ObtenerDescripcion();
    public virtual ProductoMemento CrearMemento() => _producto.CrearMemento();
    public virtual void RestaurarMemento(ProductoMemento memento) => _producto.RestaurarMemento(memento);
}
