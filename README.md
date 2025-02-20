📌 Requisitos previos

Antes de comenzar, asegúrate de tener instalado:

Visual Studio 2022 (o superior)

.NET 8 o superior

SQL Server

Entity Framework Core

🚀 Instalación

1️⃣ Clonar el repositorio

 git clone https://github.com/tuusuario/CRUD-API.git
 cd CRUD-API

2️⃣ Configurar la base de datos

En el archivo appsettings.json, actualiza la cadena de conexión a tu servidor SQL Server:

"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=CRUD_API;Trusted_Connection=True;TrustServerCertificate=True;"
}

3️⃣ Aplicar migraciones y actualizar la base de datos

Ejecuta los siguientes comandos en la terminal:

dotnet ef migrations add InitialCreate
dotnet ef database update

Esto creará la base de datos y las tablas necesarias.

4️⃣ Ejecutar la API

Ejecuta el siguiente comando para iniciar la API:

dotnet run

La API estará disponible en https://localhost:5001 o http://localhost:5000.

📡 Endpoints disponibles

La API expone los siguientes endpoints:

🔹 Obtener todos los productos

GET /api/productos

🔹 Obtener un producto por ID

GET /api/productos/{id}

🔹 Crear un nuevo producto

POST /api/productos
Content-Type: application/json
{
  "nombre": "Producto Ejemplo",
  "precio": 99.99
}

🔹 Actualizar un producto existente

PUT /api/productos/{id}
Content-Type: application/json
{
  "id": 1,
  "nombre": "Producto Actualizado",
  "precio": 149.99
}

🔹 Eliminar un producto

DELETE /api/productos/{id}

📄 Documentación con Swagger

Para ver y probar los endpoints, accede a:

https://localhost:5001/swagger

🛠 Tecnologías utilizadas

C# con ASP.NET Core

Entity Framework Core

SQL Server

Swagger para documentación
