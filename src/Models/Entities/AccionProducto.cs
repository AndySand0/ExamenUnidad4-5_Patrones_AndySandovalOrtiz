public class AccionProducto
{
    public enum Tipo
    {
        Crear,
        Modificar
    }

    public Tipo TipoAccion { get; }
    public int ProductoId { get; }
    public ProductoMemento MementoAnterior { get; }

    private AccionProducto(Tipo tipo, int id, ProductoMemento memento)
    {
        TipoAccion = tipo;
        ProductoId = id;
        MementoAnterior = memento;
    }

    public static AccionProducto Crear(int id)
        => new AccionProducto(Tipo.Crear, id, null);

    public static AccionProducto Modificar(IProducto producto)
        => new AccionProducto(Tipo.Modificar, producto.Id, producto.CrearMemento());
}
