public class Producto : IProducto
{
    public int Id { get; }
    public string Nombre { get; }
    public decimal Precio { get; }

    public Producto(int id, string nombre, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }

    public virtual string ObtenerDescripcion() => $"{Nombre} - {Precio:C}";

    public virtual ProductoMemento CrearMemento() =>
        new ProductoMemento(Id, Nombre, Precio, ObtenerDescripcion());

    public virtual void RestaurarMemento(ProductoMemento memento) { }
}
