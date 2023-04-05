namespace SchmersalGlobalTask.Domain.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(string proptype, string value) : base ($"The movie of {proptype} = {value} not found")
        {
        }
    }
}