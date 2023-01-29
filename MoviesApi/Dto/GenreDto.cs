using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Dto
{
    public class GenreDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
