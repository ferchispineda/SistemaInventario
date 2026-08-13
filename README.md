# Sistema de Gestión de Inventario Básico

## Descripción

Este proyecto corresponde a la Práctica 5 de C# y consiste en el desarrollo de un sistema de gestión de inventario mediante una aplicación de consola.

El programa permite registrar, consultar, buscar y actualizar productos utilizando estructuras (`struct`), arreglos, métodos, parámetros `ref`, ciclos y sentencias de control.

## Funcionalidades

El sistema permite:

- Registrar nuevos productos.
- Mostrar todos los productos registrados.
- Buscar productos mediante su ID.
- Actualizar el stock de un producto.
- Validar los datos ingresados por el usuario.
- Guardar el inventario en un archivo CSV.
- Cargar el inventario desde un archivo CSV.
- Mantener los datos después de cerrar el programa.

## Estructura Producto

Cada producto contiene los siguientes datos:

- ID
- Nombre
- Precio
- Stock

Se utilizó un `struct Producto` para representar cada registro del inventario.

## Tecnologías utilizadas

- C#
- .NET
- Visual Studio Code
- Git
- GitHub
- Archivos CSV

## Conceptos aplicados

Durante el desarrollo de esta práctica se utilizaron:

- Structs
- Arreglos de structs
- Parámetros `ref`
- Ciclos `do-while`
- Ciclos `for`
- Sentencias `switch`
- Métodos
- `TryParse`
- Entrada y salida por consola
- Lectura y escritura de archivos

## Persistencia de datos

El programa utiliza un archivo llamado `inventario.csv` para almacenar la información de los productos.

Gracias a esto, los productos pueden recuperarse cuando el programa se ejecuta nuevamente.

## Ejecución

Para ejecutar el proyecto:

```powershell
dotnet run