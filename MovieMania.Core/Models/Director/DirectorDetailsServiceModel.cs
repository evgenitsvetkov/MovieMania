namespace MovieMania.Core.Models.Director
{
    public class DirectorDetailsServiceModel : DirectorServiceModel
    {
        public string Bio { get; set; } = null!;

        public DateTime BirthDate { get; set; }
    }
}
