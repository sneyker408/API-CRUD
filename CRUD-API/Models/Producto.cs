using System.ComponentModel.DataAnnotations;

namespace CRUD_API.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
