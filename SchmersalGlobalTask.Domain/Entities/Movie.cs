namespace SchmersalGlobalTask.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}