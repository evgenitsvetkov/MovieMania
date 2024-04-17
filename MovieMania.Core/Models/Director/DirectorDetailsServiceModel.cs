namespace MovieMania.Core.Models.Director
{
    public class DirectorDetailsServiceModel : DirectorServiceModel
    {
        public string Bio { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}
