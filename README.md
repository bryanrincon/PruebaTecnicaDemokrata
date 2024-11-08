# Nombre del Proyecto

Descripción breve de lo que hace la aplicación. Por ejemplo:

> Una API REST para la gestión de usuarios, desarrollada en .NET 8 con Entity Framework Core y SQL Server.

## Tabla de Contenidos
1. [Características](#características)
2. [Requisitos Previos](#requisitos-previos)
3. [Instalación](#instalación)

## Características
- CRUD completo para usuarios.
- Búsqueda por ID o por primer nombre y apellido, con paginación.
- Borrado lógico para los usuarios.
- Migraciones automáticas para la creación de tablas.
- Pruebas unitarias para los métodos principales.

## Requisitos Previos
- **.NET 8 SDK** (asegúrate de tener instalado el SDK de .NET 8).
- **SQL Server** (o cualquier base de datos compatible como PostgreSQL o MariaDB).
- **Visual Studio** o **VS Code** (opcional, pero recomendado para un entorno de desarrollo completo).

## Instalación

1. Clona este repositorio:
   ```bash
   git clone <URL_DEL_REPOSITORIO>
   cd <NOMBRE_DEL_PROYECTO>
   
2. Configurar la Cadena de Conexión
Para que la aplicación se conecte a la base de datos, debes configurar la cadena de conexión en el archivo appsettings.json. Sigue estos pasos:

Abre el archivo appsettings.json en la raíz del proyecto.

Encuentra la sección "ConnectionStrings" y actualiza la cadena de conexión llamada "DefaultConnection" con los datos de tu servidor de base de datos, base de datos y credenciales.

El formato general de la cadena de conexión para SQL Server es el siguiente:

json
 ```bash
"ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
}
