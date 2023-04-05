namespace SchmersalGlobalTask.Contracts
{
    public sealed class MovieDTO
    {
        /// <summary>
        /// Unique identifier for the movie
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Title of the movie
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Genre of the movie
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Release year of the movie
        /// </summary>
        public DateTime ReleaseYear { get; set; }
    }
}
