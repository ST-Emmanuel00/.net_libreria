using System.ComponentModel.DataAnnotations;

namespace Libreria.Models
{
    public class Libro
    {
        [Key]
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public string autor { get; set; }
        public double precio { get; set; }
    }
}
