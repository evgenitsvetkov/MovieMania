namespace MovieMania.Core.Models.Director
{
    public class DirectorQueryServiceModel
    {
        public int TotalDirectorsCount { get; set; }

        public IEnumerable<DirectorServiceModel> Directors { get; set; } = new List<DirectorServiceModel>();
    }
}
