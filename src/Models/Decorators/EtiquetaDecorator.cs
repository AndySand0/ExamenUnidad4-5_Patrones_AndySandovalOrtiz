public class EtiquetaDecorator : ProductoDecorator
{
    private readonly string _clave;
    private readonly string _valor;

    public EtiquetaDecorator(IProducto producto, string clave, string valor)
        : base(producto)
    {
        _clave = clave;
        _valor = valor;
    }

    public override string ObtenerDescripcion()
        => base.ObtenerDescripcion() + $" | {_clave}: {_valor}";

    protected override ProductoDecorator CrearDecoradorDesdeClon(IProducto clonBase)
        => new EtiquetaDecorator(clonBase, _clave, _valor);
}
