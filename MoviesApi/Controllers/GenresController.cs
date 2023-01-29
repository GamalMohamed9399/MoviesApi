using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllasync()
        {
            var genres = await _context.Genres.OrderBy(g=> g.Name).ToListAsync();
            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync(GenreDto dto)
        {
            Genre genre = new Genre{ Name = dto.Name };
            await _context.AddAsync(genre);
            _context.SaveChanges();
            return Ok(genre);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,GenreDto dto)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(g=>g.Id == id);
            if (genre == null)
                return NotFound($"the genre with id not found:{id}");
            genre.Name = dto.Name;
            _context.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(g=>g.Id == id);
            if (genre == null)
                return NotFound($"the genre with id not found:{id}");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return Ok(genre);

        }
    }
}
