using System.ComponentModel.DataAnnotations;

namespace Libreria.Models
{
    public class Libro
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El titulo de la obra es obligatorio")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Teienes sibolos no permitidos")]
        public string titulo { get; set; }


        [StringLength(200, ErrorMessage = "La descripcion no debe ser tan extensa, maximo 200 caracteres")]
        [Required(ErrorMessage = "La descripcion de la obra es obligatoria")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Tienes sibolos no permitidos")]
        public string descripcion { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime fechaLanzamiento { get; set; }


        [Required(ErrorMessage = "El autor es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "No recibimos numeros" )]
        public string autor { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre {1} y {2}")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Formato de precio inválido")]
        public double precio { get; set; }
    }
}
