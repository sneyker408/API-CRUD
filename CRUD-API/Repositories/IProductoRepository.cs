using CRUD_API.Models;

namespace CRUD_API.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task<Producto> Add(Producto producto);
        Task<bool> Update(Producto producto);
        Task<bool> Delete(int id);
    }
}
