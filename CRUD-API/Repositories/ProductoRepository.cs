using CRUD_API.Data;
using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll() => await _context.Productos.ToListAsync();

        public async Task<Producto?> GetById(int id) => await _context.Productos.FindAsync(id);

        public async Task<Producto> Add(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> Update(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;
            _context.Productos.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
