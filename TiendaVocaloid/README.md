# 🎤 Tienda Vocaloid - Proyecto MVC

Proyecto ASP.NET Core MVC con CRUD completo de productos temático de Vocaloid.

## 📋 Las 4 Pantallas

| # | Pantalla | URL | Descripción |
|---|----------|-----|-------------|
| 1 | **Catálogo** | `/Producto` | Lista todos los productos |
| 2 | **Crear** | `/Producto/Create` | Formulario para agregar producto |
| 3 | **Editar** | `/Producto/Edit/{id}` | Formulario para modificar |
| 4 | **Detalles** | `/Producto/Details/{id}` | Ver detalle + eliminar |

## 🚀 Cómo ejecutarlo

### 1. Requisitos
- .NET 8 SDK
- MariaDB o MySQL corriendo en el puerto 3306
- Usuario `root` con contraseña `12345678` (o cambiá la connection string)

### 2. Crear la base de datos

Abrí tu cliente de MariaDB (o usá el extension DB Code en VS Code) y ejecutá el archivo:

```
script_db.sql
```

O ejecutá estos comandos:

```sql
CREATE DATABASE tiendavocaloid;
USE tiendavocaloid;

CREATE TABLE Producto (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Categoria VARCHAR(50) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Descripcion TEXT
);
```

### 3. Restaurar paquetes y correr

```bash
cd TiendaVocaloid
dotnet restore
dotnet run
```

Abrí el navegador en: **https://localhost:5xxx** (el puerto te lo muestra la terminal)

## 🔧 Cambiar la contraseña de la base de datos

Editá el archivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=tiendavocaloid;User=root;Password=TU_PASSWORD;"
}
```

## 📦 Estructura del proyecto

```
TiendaVocaloid/
├── Controllers/
│   ├── ProductoController.cs   ← Lógica del CRUD
│   └── HomeController.cs
├── Models/
│   └── Producto.cs
├── Views/
│   ├── Producto/
│   │   ├── Index.cshtml        ← Pantalla 1 (Catálogo)
│   │   ├── Create.cshtml       ← Pantalla 2 (Crear)
│   │   ├── Edit.cshtml         ← Pantalla 3 (Editar)
│   │   └── Details.cshtml      ← Pantalla 4 (Detalles)
│   └── Shared/
│       └── _Layout.cshtml
├── script_db.sql
└── appsettings.json
```

¡Listo para usar! 💙
