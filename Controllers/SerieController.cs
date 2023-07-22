using GeekWebApi.Context;
using GeekWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekWebApi.Controllers
{
    [ApiController]
    [Route("controller/serie")]
    public class SerieController : Controller
    {
        private ILogger<FilmeController> _logger;
        private readonly GeekWebApiContext _context;

        public SerieController(ILogger<FilmeController> logger, GeekWebApiContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("getallseries")]
        public ActionResult<IEnumerable<Livro>> GetAllSeries()
        {
            var allBooks = _context.Series.ToList();
            if (allBooks.Count == 0) return NotFound();

            return Ok(allBooks);
        }

        [HttpGet("getseriesbyname")]
        public ActionResult<IEnumerable<Filme>> GetSeriesByName(string name)
        {
            try
            {
                var movies = _context.Series
                    .Where(m => m.Nome.ToLower().Contains(name.ToLower()));

                if (movies == null) return NotFound();

                return Ok(movies);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("getbooksbyempresa")]
        public ActionResult<IEnumerable<Filme>> GetBooksByEmpresa(string empresa)
        {
            try
            {
                var movies = _context.Series
                    .Where(m => m.Empresa.ToLower().Contains(empresa.ToLower()));

                if (movies == null) return NotFound();

                return Ok(movies);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
