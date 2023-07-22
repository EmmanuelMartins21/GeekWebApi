using GeekWebApi.Context;
using GeekWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekWebApi.Controllers
{
    [ApiController]
    [Route("controller/books")]
    public class LivroController : Controller
    {
        private ILogger<FilmeController> _logger;
        private readonly GeekWebApiContext _context;

        public LivroController(ILogger<FilmeController> logger, GeekWebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getallbooks")]
        public ActionResult<IEnumerable<Livro>> GetAlBooks()
        {
            var allBooks = _context.Livros.ToList();
            if (allBooks.Count == 0) return NotFound();

            return Ok(allBooks);
        }

        [HttpGet("getbooksbyname")]
        public ActionResult<IEnumerable<Filme>> GetBooksByName(string name)
        {
            try
            {
                var movies = _context.Livros
                    .Where(m => m.Nome.ToLower().Contains(name.ToLower()));

                if (movies == null) return NotFound();

                return Ok(movies);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("getbooksbyeditora")]
        public ActionResult<IEnumerable<Filme>> GetBooksByEditora(string editora)
        {
            try
            {
                var movies = _context.Livros
                    .Where(m => m.Editora.ToLower().Contains(editora.ToLower()));

                if (movies == null) return NotFound();

                return Ok(movies);
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("postbooks")]
        public ActionResult<IEnumerable<Livro>> PostBooks(List<Livro> books)
        {
            try
            {
                if (books.Count > 0)
                {
                    var allBooks = _context.Livros.ToList();
                    if (allBooks.Count != 0)
                    {
                        foreach (var b in books)
                        {
                            bool livroJaExiste = allBooks.Any(livro => livro.Nome == b.Nome);

                            if (!livroJaExiste)
                            {
                                _context.Livros.Add(b);
                                _context.SaveChanges();
                            }
                        }
                    }

                    _logger.LogInformation($"POST /Livros cadastrados com Sucesso");
                }

                return CreatedAtAction(nameof(GetAlBooks), new { books }, books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST /Livro - Ocorreu um erro ao criar a tarefa");
                return StatusCode(500);
            }
        }
    }
}
