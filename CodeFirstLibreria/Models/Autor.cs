namespace CodeFirstLibreria.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public required string NombreCompleto{ get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
