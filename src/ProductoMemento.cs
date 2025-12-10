public class ProductoMemento
{
    public int Id { get; }
    public string Nombre { get; }
    public decimal Precio { get; }
    public string Descripcion { get; }

    public ProductoMemento(int id, string nombre, decimal precio, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Descripcion = descripcion;
    }
}
