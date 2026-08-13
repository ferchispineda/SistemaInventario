using System;
using System.IO;
using System.Collections.Generic;

struct Producto
{
    public int ID;
    public string Nombre;
    public double Precio;
    public int Stock;
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "Sistema de Gestión de Inventario v1.0";

        const int CAPACIDAD = 10;
        Producto[] inventario = new Producto[CAPACIDAD];
        int totalRegistros = 0;

        string archivo = "inventario.csv";

        CargarInventario(inventario, ref totalRegistros, archivo, CAPACIDAD);

        string opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║     SISTEMA DE INVENTARIO - MENÚ     ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1. Registrar producto                ║");
            Console.WriteLine("║ 2. Mostrar todos los productos       ║");
            Console.WriteLine("║ 3. Salir                             ║");
            Console.WriteLine("║ 4. Buscar producto por ID            ║");
            Console.WriteLine("║ 5. Actualizar stock                  ║");
            Console.WriteLine("║ 6. Guardar inventario en CSV         ║");
            Console.WriteLine("║ 7. Cargar inventario desde CSV       ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.Write("\nSelecciona una opción: ");
            opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    RegistrarProducto(
                        inventario,
                        ref totalRegistros,
                        CAPACIDAD);
                    break;

                case "2":
                    MostrarProductos(
                        inventario,
                        totalRegistros);
                    break;

                case "3":
                    GuardarInventario(
                        inventario,
                        totalRegistros,
                        archivo);

                    Console.WriteLine(
                        "\nInventario guardado.");

                    Console.WriteLine(
                        "Cerrando el sistema... ¡Hasta pronto!");
                    break;

                case "4":
                    BuscarProducto(
                        inventario,
                        totalRegistros);
                    break;

                case "5":
                    ActualizarStock(
                        inventario,
                        totalRegistros);
                    break;

                case "6":
                    GuardarInventario(
                        inventario,
                        totalRegistros,
                        archivo);

                    Console.WriteLine(
                        "\nInventario guardado correctamente.");

                    Console.WriteLine(
                        "Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;

                case "7":
                    CargarInventario(
                        inventario,
                        ref totalRegistros,
                        archivo,
                        CAPACIDAD);

                    Console.WriteLine(
                        "\nInventario cargado correctamente.");

                    Console.WriteLine(
                        "Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("\nOpción inválida.");
                    Console.WriteLine(
                        "Presiona Enter para continuar...");
                    Console.ReadLine();
                    break;
            }

        } while (opcion != "3");
    }


    static void RegistrarProducto(
        Producto[] inventario,
        ref int total,
        int capacidad)
    {
        Console.Clear();
        Console.WriteLine("── REGISTRAR NUEVO PRODUCTO ──\n");

        if (total >= capacidad)
        {
            Console.WriteLine(
                "El inventario está lleno.");

            Console.ReadLine();
            return;
        }

        int id;

        while (true)
        {
            Console.Write("ID del producto: ");

            if (int.TryParse(
                Console.ReadLine(),
                out id) && id > 0)
            {
                break;
            }

            Console.WriteLine(
                "ID inválido. Ingresa solamente números.");
        }

        for (int i = 0; i < total; i++)
        {
            if (inventario[i].ID == id)
            {
                Console.WriteLine(
                    "\nEse ID ya está registrado.");

                Console.ReadLine();
                return;
            }
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine(
                "El nombre no puede estar vacío.");

            Console.Write("Nombre: ");
            nombre = Console.ReadLine() ?? "";
        }

        double precio;

        while (true)
        {
            Console.Write("Precio unitario: $");

            if (double.TryParse(
                Console.ReadLine(),
                out precio) && precio >= 0)
            {
                break;
            }

            Console.WriteLine(
                "Precio inválido. Intenta nuevamente.");
        }

        int stock;

        while (true)
        {
            Console.Write("Stock disponible: ");

            if (int.TryParse(
                Console.ReadLine(),
                out stock) && stock >= 0)
            {
                break;
            }

            Console.WriteLine(
                "Stock inválido.");
        }

        inventario[total].ID = id;
        inventario[total].Nombre = nombre.Trim();
        inventario[total].Precio = precio;
        inventario[total].Stock = stock;

        total++;

        Console.WriteLine(
            "\nProducto registrado exitosamente.");

        Console.WriteLine(
            $"Total en inventario: {total}");

        Console.WriteLine(
            "\nPresiona Enter para continuar...");

        Console.ReadLine();
    }


    static void MostrarProductos(
        Producto[] inventario,
        int total)
    {
        Console.Clear();

        Console.WriteLine(
            "── LISTADO COMPLETO DE INVENTARIO ──\n");

        if (total == 0)
        {
            Console.WriteLine(
                "No hay productos registrados.");

            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            $"{"ID",-6} {"Nombre",-20} {"Precio",10} {"Stock",8}");

        Console.WriteLine(
            new string('-', 48));

        for (int i = 0; i < total; i++)
        {
            Console.WriteLine(
                $"{inventario[i].ID,-6} " +
                $"{inventario[i].Nombre,-20} " +
                $"${inventario[i].Precio,9:F2} " +
                $"{inventario[i].Stock,8}");
        }

        Console.WriteLine(
            $"\nTotal de productos: {total}");

        Console.WriteLine(
            "\nPresiona Enter para continuar...");

        Console.ReadLine();
    }


    static void BuscarProducto(
        Producto[] inventario,
        int total)
    {
        Console.Clear();

        Console.WriteLine(
            "── BUSCAR PRODUCTO POR ID ──\n");

        int idBuscado;

        Console.Write("Ingresa el ID a buscar: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out idBuscado))
        {
            Console.WriteLine("ID inválido.");

            Console.Write(
                "Ingresa nuevamente el ID: ");
        }

        for (int i = 0; i < total; i++)
        {
            if (inventario[i].ID == idBuscado)
            {
                Console.WriteLine(
                    "\nProducto encontrado:");

                Console.WriteLine(
                    $"ID: {inventario[i].ID}");

                Console.WriteLine(
                    $"Nombre: {inventario[i].Nombre}");

                Console.WriteLine(
                    $"Precio: ${inventario[i].Precio:F2}");

                Console.WriteLine(
                    $"Stock: {inventario[i].Stock}");

                Console.WriteLine(
                    "\nPresiona Enter para continuar...");

                Console.ReadLine();
                return;
            }
        }

        Console.WriteLine(
            "\nProducto no encontrado.");

        Console.WriteLine(
            "\nPresiona Enter para continuar...");

        Console.ReadLine();
    }


    static void ActualizarStock(
        Producto[] inventario,
        int total)
    {
        Console.Clear();

        Console.WriteLine(
            "── ACTUALIZAR STOCK ──\n");

        int idBuscado;

        Console.Write(
            "Ingresa el ID del producto: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out idBuscado))
        {
            Console.WriteLine("ID inválido.");

            Console.Write(
                "Ingresa nuevamente el ID: ");
        }

        for (int i = 0; i < total; i++)
        {
            if (inventario[i].ID == idBuscado)
            {
                Console.WriteLine(
                    $"\nProducto: {inventario[i].Nombre}");

                Console.WriteLine(
                    $"Stock actual: {inventario[i].Stock}");

                int nuevoStock;

                Console.Write("\nNuevo stock: ");

                while (!int.TryParse(
                    Console.ReadLine(),
                    out nuevoStock)
                    || nuevoStock < 0)
                {
                    Console.WriteLine(
                        "Stock inválido.");

                    Console.Write(
                        "Ingresa nuevamente el stock: ");
                }

                inventario[i].Stock = nuevoStock;

                Console.WriteLine(
                    "\nStock actualizado correctamente.");

                Console.WriteLine(
                    $"Nuevo stock: {inventario[i].Stock}");

                Console.WriteLine(
                    "\nPresiona Enter para continuar...");

                Console.ReadLine();
                return;
            }
        }

        Console.WriteLine(
            "\nProducto no encontrado.");

        Console.ReadLine();
    }


    static void GuardarInventario(
        Producto[] inventario,
        int total,
        string archivo)
    {
        List<string> lineas =
            new List<string>();

        lineas.Add("ID,Nombre,Precio,Stock");

        for (int i = 0; i < total; i++)
        {
            lineas.Add(
                $"{inventario[i].ID}," +
                $"{inventario[i].Nombre}," +
                $"{inventario[i].Precio}," +
                $"{inventario[i].Stock}");
        }

        File.WriteAllLines(
            archivo,
            lineas);
    }


    static void CargarInventario(
        Producto[] inventario,
        ref int total,
        string archivo,
        int capacidad)
    {
        if (!File.Exists(archivo))
        {
            return;
        }

        string[] lineas =
            File.ReadAllLines(archivo);

        total = 0;

        for (int i = 1;
            i < lineas.Length && total < capacidad;
            i++)
        {
            string[] datos =
                lineas[i].Split(',');

            if (datos.Length == 4 &&
                int.TryParse(datos[0], out int id) &&
                double.TryParse(datos[2], out double precio) &&
                int.TryParse(datos[3], out int stock))
            {
                inventario[total].ID = id;
                inventario[total].Nombre = datos[1];
                inventario[total].Precio = precio;
                inventario[total].Stock = stock;

                total++;
            }
        }
    }
}