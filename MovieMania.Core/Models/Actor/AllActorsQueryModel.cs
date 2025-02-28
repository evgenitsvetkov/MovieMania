using MovieMania.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Actor
{
    public class AllActorsQueryModel
    {
        public int ActorsPerPage { get; } = 6;

        [Display(Name = "Search")]
        public string SearchTerm { get; set; } = null!;

        public ActorSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalActorsCount { get; set; }

        public IEnumerable<ActorServiceModel> Actors { get; set; } = new List<ActorServiceModel>();
    }
}
