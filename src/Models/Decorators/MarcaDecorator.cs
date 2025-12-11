public class MarcaDecorator : ProductoDecorator
{
    private readonly string _marca;

    public MarcaDecorator(IProducto producto, string marca)
        : base(producto) => _marca = marca;

    public override string ObtenerDescripcion()
        => base.ObtenerDescripcion() + $" | Marca: {_marca}";

    protected override ProductoDecorator CrearDecoradorDesdeClon(IProducto clonBase)
        => new MarcaDecorator(clonBase, _marca);
}
