namespace CodeFirstLibreria.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required int NumPaginas { get; set; }
        public int AutorId { get; set; }
    }
}
