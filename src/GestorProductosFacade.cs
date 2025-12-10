using System;
using System.Collections.Generic;

public class GestorProductosFacade
{
    private readonly ProductoRepository _repo = new();
    private readonly Stack<ProductoMemento> _historial = new();

    public IProducto CrearProducto(int id, string nombre, decimal precio,
                                   string categoria = null, string marca = null,
                                   Dictionary<string, string> etiquetas = null)
    {
        var builder = new ProductoBuilder().CrearBase(id, nombre, precio);

        if (!string.IsNullOrEmpty(categoria)) builder.ConCategoria(categoria);
        if (!string.IsNullOrEmpty(marca)) builder.ConMarca(marca);
        if (etiquetas != null)
            foreach (var kv in etiquetas)
                builder.ConEtiqueta(kv.Key, kv.Value);

        var producto = builder.Construir();
        _repo.Guardar(producto);
        return producto;
    }

    public void AgregarCategoria(int id, string categoria) => Decorar(id, p => new CategoriaDecorator(p, categoria));
    public void AgregarMarca(int id, string marca) => Decorar(id, p => new MarcaDecorator(p, marca));
    public void AgregarEtiqueta(int id, string clave, string valor) => Decorar(id, p => new EtiquetaDecorator(p, clave, valor));

    private void Decorar(int id, Func<IProducto, IProducto> decorador)
    {
        var p = _repo.Obtener(id);
        if (p != null)
        {
            _historial.Push(p.CrearMemento());
            p = decorador(p);
            _repo.Guardar(p);
        }
    }

    public void Deshacer()
    {
        if (_historial.Count == 0) return;
        var memento = _historial.Pop();
        var p = _repo.Obtener(memento.Id);
        p?.RestaurarMemento(memento);
    }

    public IProducto ObtenerProducto(int id) => _repo.Obtener(id);
    public IEnumerable<IProducto> ListarProductos() => _repo.ObtenerTodos();
}
