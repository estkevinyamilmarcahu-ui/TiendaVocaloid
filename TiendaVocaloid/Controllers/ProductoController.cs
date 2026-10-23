using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TiendaVocaloid.Models;

namespace TiendaVocaloid.Controllers
{
    public class ProductoController : Controller
    {
        private readonly string _connectionString;

        public ProductoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=localhost;Port=3306;Database=tiendavocaloid;User=root;Password=12345678;";
        }

        // ========== PANTALLA 1: CATÁLOGO (Index) ==========
        public IActionResult Index()
        {
            var productos = new List<Producto>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT Id, Nombre, Precio, Categoria, Stock, Descripcion FROM Producto", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Precio = reader.GetDecimal("Precio"),
                    Categoria = reader.GetString("Categoria"),
                    Stock = reader.GetInt32("Stock"),
                    Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion")
                });
            }

            return View(productos);
        }

        // ========== PANTALLA 2: CREAR ==========
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand(
                "INSERT INTO Producto (Nombre, Precio, Categoria, Stock, Descripcion) VALUES (@Nombre, @Precio, @Categoria, @Stock, @Descripcion)",
                connection);

            command.Parameters.AddWithValue("@Nombre", producto.Nombre);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.Parameters.AddWithValue("@Categoria", producto.Categoria);
            command.Parameters.AddWithValue("@Stock", producto.Stock);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? (object)DBNull.Value);

            command.ExecuteNonQuery();

            return RedirectToAction(nameof(Index));
        }

        // ========== PANTALLA 3: EDITAR ==========
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var producto = ObtenerProducto(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand(
                "UPDATE Producto SET Nombre=@Nombre, Precio=@Precio, Categoria=@Categoria, Stock=@Stock, Descripcion=@Descripcion WHERE Id=@Id",
                connection);

            command.Parameters.AddWithValue("@Id", producto.Id);
            command.Parameters.AddWithValue("@Nombre", producto.Nombre);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.Parameters.AddWithValue("@Categoria", producto.Categoria);
            command.Parameters.AddWithValue("@Stock", producto.Stock);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? (object)DBNull.Value);

            command.ExecuteNonQuery();

            return RedirectToAction(nameof(Index));
        }

        // ========== PANTALLA 4: DETALLES + ELIMINAR ==========
        [HttpGet]
        public IActionResult Details(int id)
        {
            var producto = ObtenerProducto(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand("DELETE FROM Producto WHERE Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            return RedirectToAction(nameof(Index));
        }

        // ========== Método auxiliar ==========
        private Producto? ObtenerProducto(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand(
                "SELECT Id, Nombre, Precio, Categoria, Stock, Descripcion FROM Producto WHERE Id=@Id",
                connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Producto
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Precio = reader.GetDecimal("Precio"),
                    Categoria = reader.GetString("Categoria"),
                    Stock = reader.GetInt32("Stock"),
                    Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion")
                };
            }

            return null;
        }
    }
}
