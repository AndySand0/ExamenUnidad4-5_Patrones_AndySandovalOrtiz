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

    public virtual ProductoMemento CrearMemento()
        => new ProductoMemento(Clonar());

    public virtual IProducto Clonar()
    {
        var baseClon = _producto.Clonar();
        return CrearDecoradorDesdeClon(baseClon);
    }

    protected abstract ProductoDecorator CrearDecoradorDesdeClon(IProducto clonBase);
}
