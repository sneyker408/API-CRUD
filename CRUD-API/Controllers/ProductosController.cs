using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_API.Models; // Namespace correcto para tu modelo
using Microsoft.EntityFrameworkCore;
using CRUD_API.Data; // Namespace correcto para tu contexto

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Estado de conexión con el servidor
        [HttpGet]
        [Route("ConexionServidor")]
        public async Task<ActionResult<string>> GetConexionServidor()
        {
            return Ok("Conectado");
        }

        // Estado de conexión con la tabla de la base de datos
        [HttpGet]
        [Route("ConexionDB")]
        public async Task<ActionResult<string>> GetConexionDB()
        {
            try
            {
                var productos = await _context.Productos.ToListAsync();
                return Ok("Conexión exitosa a la base de datos");
            }
            catch (Exception ex)
            {
                return BadRequest("Error de conexión con la base de datos");
            }
        }

        // Obtener todos los productos
        [HttpGet("Listado")]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var lista = await _context.Productos.ToListAsync();
            return Ok(lista);
        }

        // Obtener un solo producto por ID
        [HttpGet]
        [Route("ConsultarId/{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            return Ok(producto);
        }

        // Crear un nuevo producto
        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateProducto(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok("Producto creado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al crear el producto");
            }
        }

        // Agregar múltiples productos
        [HttpPost("AgregarListado")]
        public async Task<ActionResult<string>> AgregarListadoProducto(List<Producto> productos)
        {
            try
            {
                foreach (var producto in productos)
                {
                    var existeProducto = await _context.Productos
                        .FirstOrDefaultAsync(p => p.Nombre == producto.Nombre);

                    if (existeProducto == null)
                    {
                        _context.Productos.Add(producto);
                    }
                }

                await _context.SaveChangesAsync();
                return Ok("Productos agregados con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al agregar productos");
            }
        }

        // Actualizar un producto existente
        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult> UpdateProducto(int id, Producto producto)
        {
            var DbProducto = await _context.Productos.FindAsync(id);
            if (DbProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            DbProducto.Nombre = producto.Nombre;
            DbProducto.Precio = producto.Precio;
            DbProducto.Stock = producto.Stock;

            await _context.SaveChangesAsync();
            return Ok("Producto actualizado con éxito");
        }

        // Eliminar un producto
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteProducto(int id)
        {
            var DbProducto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);
            if (DbProducto == null)
            {
                return NotFound("Producto no encontrado");
            }

            try
            {
                _context.Productos.Remove(DbProducto);
                await _context.SaveChangesAsync();
                return Ok("Producto eliminado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest("No fue posible eliminar el producto");
            }
        }
    }
}
