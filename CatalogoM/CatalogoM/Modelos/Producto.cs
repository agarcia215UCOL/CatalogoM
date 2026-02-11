
using System.ComponentModel.DataAnnotations;
namespace CatalogoM.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El tipo de producto es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "El departamento es requerido")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string? Departamento { get; set; }
        [Required(ErrorMessage = "El precio del producto es requerido")]
        public int Precio { get; set; }
        //propiedad de navegación EF
        public int ClasificacionId { get; set; }
        virtual public Clasificacion? Clasificacion { get; set; }
        virtual public ICollection<Marca>? Marcas { get; set; }
    }
}
