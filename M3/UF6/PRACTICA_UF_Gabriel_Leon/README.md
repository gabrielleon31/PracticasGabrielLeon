# PRACTICA UF6: API de Productos

Este proyecto implementa una API REST sencilla de gestión de **Productos** utilizando .NET 8 y SQLite, siguiendo los requisitos de la UF6.

## Requisitos previos

* [.NET 8 SDK](https://dotnet.microsoft.com/)
* [SQLite](https://www.sqlite.org/)
* Herramienta de EF Core: `dotnet-ef`

## Instalación y configuración

1. Clona o descarga este repositorio y sitúate en la carpeta del proyecto:

   ```bash
   cd PRACTICA_UF_Gabriel_Leon
   ```

2. Asegúrate de instalar la herramienta de EF Core (solo la primera vez):

   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. Restaura paquetes NuGet:

   ```bash
   dotnet restore
   ```

4. Crea la migración inicial y actualiza la base de datos:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

   Esto generará la carpeta `Migrations` y el archivo `productos.db` en la raíz.

5. (Opcional) Modifica la cadena de conexión en `appsettings.json` si quieres cambiar la ubicación o el nombre de la base de datos.

## Estructura del proyecto

* **Program.cs**: configura el servicio, endpoints CRUD y Swagger en un único archivo.
* **appsettings.json**: contiene la cadena de conexión bajo `ConnectionStrings:DefaultConnection`.
* **Migrations/**: migraciones de EF Core.
* **productos.db**: base de datos SQLite generada.

## Ejecución

Arranca la API con:

```bash
dotnet run
```

Verás en la consola que aplica migraciones pendientes y levanta el servidor en `http://localhost:5000` (o el puerto que indique la salida).

## Endpoints disponibles

| Método | Endpoint              | Descripción                     |
| ------ | --------------------- | ------------------------------- |
| GET    | `/api/productos`      | Lista todos los productos       |
| GET    | `/api/productos/{id}` | Obtiene un producto por su `id` |
| POST   | `/api/productos`      | Crea un nuevo producto          |
| PUT    | `/api/productos/{id}` | Actualiza un producto existente |
| DELETE | `/api/productos/{id}` | Elimina un producto por su `id` |

### Ejemplos con Talend API Tester

A continuación tienes ejemplos de cómo configurar tus peticiones en Talend API Tester:

1. **Listar productos**

   * Método: **GET**
   * URL: `http://localhost:5000/api/productos`
   * Header: `Accept: application/json`
   * Ejecuta la petición y verás un array JSON con los productos.

2. **Crear un producto**

   * Método: **POST**
   * URL: `http://localhost:5000/api/productos`
   * Headers:

     * `Content-Type: application/json`
   * Body (raw JSON):

     ```json
     {
       "nombre": "Zapato",
       "precio": 49.99
     }
     ```
   * Ejecuta la petición y verás un **201 Created** con el objeto creado.

3. **Actualizar un producto**

   * Método: **PUT**
   * URL: `http://localhost:5000/api/productos/{id}` (sustituye `{id}` por el identificador real, p.ej. `1`)
   * Headers:

     * `Content-Type: application/json`
   * Body (raw JSON):

     ```json
     {
       "id": 1,
       "nombre": "Zapato123",
       "precio": 59.99
     }
     ```
   * Ejecuta la petición y obtendrás **204 No Content**, indicando que la actualización se ha realizado.

4. **Eliminar un producto**

   * Método: **DELETE**
   * URL: `http://localhost:5000/api/productos/{id}`
   * Ejecuta la petición y obtendrás **204 No Content**, indicando que el producto se ha borrado.

## Swagger UI

Para probar la API de forma interactiva, abre en tu navegador:

```
http://localhost:5000/swagger/index.html
```

Ahí podrás ver la definición OpenAPI y ejecutar cada endpoint directamente.

---

> **Autor:** Gabriel León
> **Práctica:** UF6 API Web con .NET y SQLite
