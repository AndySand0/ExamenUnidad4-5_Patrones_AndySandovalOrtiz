public class CategoriaDecorator : ProductoDecorator
{
    private readonly string _categoria;

    public CategoriaDecorator(IProducto producto, string categoria)
        : base(producto) => _categoria = categoria;

    public override string ObtenerDescripcion()
        => base.ObtenerDescripcion() + $" | Categoría: {_categoria}";

    protected override ProductoDecorator CrearDecoradorDesdeClon(IProducto clonBase)
        => new CategoriaDecorator(clonBase, _categoria);
}
