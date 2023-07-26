using GeekWebApi.Context;
using GeekWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GeekWebApi.Controllers
{
    [ApiController]
    [Route("controller/anime")]
    public class AnimeController : Controller
    {
        private ILogger<FilmeController> _logger;
        private readonly GeekWebApiContext _context;

        public AnimeController(ILogger<FilmeController> logger, GeekWebApiContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("getallanime")]
        public ActionResult<IEnumerable<Anime>> GetAllAnimes()
        {
            var allAnimes = _context.Animes.ToList();
            if (allAnimes.Count == 0) return NotFound();

            return Ok(allAnimes);
        }

        [HttpGet("getanimesbyname")]
        public ActionResult<IEnumerable<Anime>> GetAnimesByName(string name)
        {
            try
            {
                var animes = _context.Animes
                    .Where(m => m.Nome.ToLower().Contains(name.ToLower()));

                if (animes == null) return NotFound();

                return Ok(animes);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("getanimesbygender")]
        public ActionResult<IEnumerable<Anime>> GetAnimesByGender(string gender)
        {
            try
            {
                var animes = _context.Animes
                    .Where(m => m.Genero.ToLower().Contains(gender.ToLower()));

                if (animes == null) return NotFound();

                return Ok(animes);
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("postanimes")]
        public ActionResult<IEnumerable<Anime>> PostAnimes(List<Anime> animes)
        {
            try
            {
                if (animes.Count > 0)
                {
                    var allAnimes = _context.Animes.ToList();
                    if (allAnimes.Count != 0)
                    {
                        foreach (var a in animes)
                        {
                            bool animeExist = allAnimes.Any(animes => animes == a);

                            if (!animeExist)
                            {
                                _context.Animes.Add(a);
                                _context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        foreach (var a in animes)
                        {
                            _context.Animes.Add(a);
                            _context.SaveChanges();
                        }
                    }
                    _logger.LogInformation($"POST /Livros cadastrados com Sucesso");
                    _context.SaveChanges();
                }

                return CreatedAtAction(nameof(GetAllAnimes), new { animes }, animes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST /Livro - Ocorreu um erro ao criar a tarefa");
                return StatusCode(500);
            }
        }
    }
}
