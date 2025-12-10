using System.Collections.Generic;

public class ProductoRepository
{
    private readonly Dictionary<int, IProducto> _productos = new();

    public void Guardar(IProducto p) => _productos[p.Id] = p;
    public IProducto Obtener(int id) => _productos.ContainsKey(id) ? _productos[id] : null;
    public IEnumerable<IProducto> ObtenerTodos() => _productos.Values;
}
