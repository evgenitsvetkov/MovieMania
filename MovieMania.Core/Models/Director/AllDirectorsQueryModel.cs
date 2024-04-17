using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Director
{
    public class AllDirectorsQueryModel
    {
        public int DirectorsPerPage { get; } = 6;

        [Display(Name = "Search")]
        public string SearchTerm { get; set; } = null!;

        public int CurrentPage { get; set; } = 1;

        public int TotalDirectorsCount { get; set; }

        public IEnumerable<DirectorServiceModel> Directors { get; set; } = new List<DirectorServiceModel>();
    }
}
