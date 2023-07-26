using GeekWebApi.Context;
using GeekWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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
        public ActionResult<IEnumerable<Serie>> GetAllSeries()
        {
            var allSeries = _context.Series.ToList();
            if (allSeries.Count == 0) return NotFound();

            return Ok(allSeries);
        }

        [HttpGet("getseriesbyname")]
        public ActionResult<IEnumerable<Serie>> GetSeriesByName(string name)
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
        public ActionResult<IEnumerable<Serie>> GetBooksByEmpresa(string empresa)
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
               

        [Authorize]        
        [HttpPost("postseries")]
        public ActionResult<IEnumerable<Serie>> Postseries(List<Serie> series)
        {
            try
            {
                if (series.Count > 0)
                {
                    var allSeries = _context.Series.ToList();
                    if (allSeries.Count != 0)
                    {
                        foreach (var s in series)
                        {
                            bool serieExist = allSeries.Any(series => series == s);

                            if (!serieExist)
                            {
                                _context.Series.Add(s);
                                _context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        foreach (var s in series)
                        {
                            _context.Series.Add(s);
                            _context.SaveChanges();
                        }
                    }
                    _logger.LogInformation($"POST /Livros cadastrados com Sucesso");
                    _context.SaveChanges();
                }

                return CreatedAtAction(nameof(GetAllSeries), new { series }, series);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST /Livro - Ocorreu um erro ao criar a tarefa");
                return StatusCode(500);
            }
        }
    }
}
