using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Director
{
    public class DirectorDetailsServiceModel : DirectorServiceModel
    {
        public string Bio { get; set; } = null!;
        
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
