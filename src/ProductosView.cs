using System;
using System.Collections.Generic;

public class ProductosView
{
    private readonly GestorProductosFacade _gestor = new();

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("====== GESTOR DE PRODUCTOS ======");
            Console.WriteLine("1. Crear producto");
            Console.WriteLine("2. Agregar categoría");
            Console.WriteLine("3. Agregar marca");
            Console.WriteLine("4. Agregar etiqueta");
            Console.WriteLine("5. Ver producto");
            Console.WriteLine("6. Listar todos los productos");
            Console.WriteLine("7. Deshacer último cambio");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;
            Console.Clear();

            switch (opcion)
            {
                case 1: CrearProducto(); break;
                case 2: AgregarCategoria(); break;
                case 3: AgregarMarca(); break;
                case 4: AgregarEtiqueta(); break;
                case 5: VerProducto(); break;
                case 6: ListarProductos(); break;
                case 7: _gestor.Deshacer(); break;
                case 0: Console.WriteLine("Saliendo..."); break;
                default: Console.WriteLine("Opción inválida"); break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla...");
                Console.ReadKey();
            }

        } while (opcion != 0);
    }

    private void CrearProducto()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Nombre: "); string nombre = Console.ReadLine();
        Console.Write("Precio: "); decimal precio = decimal.Parse(Console.ReadLine());
        Console.Write("Categoría (opcional): "); string cat = Console.ReadLine();
        Console.Write("Marca (opcional): "); string marca = Console.ReadLine();

        var producto = _gestor.CrearProducto(id, nombre, precio,
                                             string.IsNullOrEmpty(cat) ? null : cat,
                                             string.IsNullOrEmpty(marca) ? null : marca);
        Console.WriteLine("Producto creado:\n" + producto.ObtenerDescripcion());
    }

    private void AgregarCategoria()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Categoría: "); string cat = Console.ReadLine();
        _gestor.AgregarCategoria(id, cat);
    }

    private void AgregarMarca()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Marca: "); string marca = Console.ReadLine();
        _gestor.AgregarMarca(id, marca);
    }

    private void AgregarEtiqueta()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Clave: "); string clave = Console.ReadLine();
        Console.Write("Valor: "); string valor = Console.ReadLine();
        _gestor.AgregarEtiqueta(id, clave, valor);
    }

    private void VerProducto()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        var p = _gestor.ObtenerProducto(id);
        if (p != null) Console.WriteLine(p.ObtenerDescripcion());
        else Console.WriteLine("Producto no encontrado.");
    }

    private void ListarProductos()
    {
        foreach (var p in _gestor.ListarProductos())
            Console.WriteLine(p.ObtenerDescripcion());
    }
}
