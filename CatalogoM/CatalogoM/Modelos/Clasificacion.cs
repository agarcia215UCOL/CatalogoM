namespace CatalogoM.Modelos
{
    public class Clasificacion
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        //propiedad de navegación EF
        public ICollection<Producto>? Productos { get; set; }
    }
}
