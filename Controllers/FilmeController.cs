﻿
using GeekWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using GeekWebApi.Context;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GeekWebApi.Controllers
{
    [ApiController]    
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private ILogger<FilmeController> _logger;
        private readonly GeekWebApiContext _context;

        public FilmeController(ILogger<FilmeController> logger, GeekWebApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetMoviesMarvel")]
        public ActionResult<IEnumerable<Filme>> GetMoviesMarvel()
        {
            _logger.LogInformation("GET /Filmes - Iniciando busca de todos os filmes cadastrados" + DateTime.Now);
            try
            {
                var marvelMovies = _context.Filmes.ToList()
                    .Where(dc => dc.Empresa.ToLower()
                    .Contains("marvel")).ToList();


                if (marvelMovies.Count == 0)
                {
                    _logger.LogInformation("GET /Filmes - Nenhum filme encontrado " + DateTime.Now);
                    return NotFound();
                }
                _logger.LogInformation("GET /Filmes - Filmes localizados com sucesso " + DateTime.Now);
                return marvelMovies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET /Filmes - Ocorreu um erro ao buscar os filmes");
                return StatusCode(500);
            }
        }


        [HttpGet("GetMoviesDC")]
        public ActionResult<IEnumerable<Filme>> GetMoviesDc()
        {
            _logger.LogInformation("GET /Filmes - Iniciando busca de todos os filmes cadastrados" + DateTime.Now);
            try
            {
                var dcMovies = _context.Filmes.ToList()
                    .Where(dc => dc.Empresa.ToLower()
                    .Contains("warner")).ToList();

                if (dcMovies.Count == 0)
                {
                    _logger.LogInformation("GET /Filmes - Nenhum filme encontrado " + DateTime.Now);
                    return NotFound();
                }
                _logger.LogInformation("GET /Filmes - Filmes localizados com sucesso " + DateTime.Now);
                return dcMovies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET /Filmes - Ocorreu um erro ao buscar os filmes");
                return StatusCode(500);
            }
        }

        [HttpGet("GetAllMoviesDB")]
        public ActionResult<IEnumerable<Filme>> GetAllMoviesDB()
        {           
            var allmovies = _context.Filmes.ToList();
            if (allmovies.Count == 0) return NotFound();

            return Ok(allmovies);
        }

        [HttpGet("GetMoviesByName")]
        public ActionResult<IEnumerable<Filme>> GetMoviesByName(string name)
        {
            try
            {
                var movies = _context.Filmes
                    .Where(m => m.Nome.ToLower().Contains(name.ToLower()));

                if(movies == null) return NotFound();

                return Ok(movies);
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("PostMovies")]
        public ActionResult<IEnumerable<Filme>> PostMovies(List<Filme> movies)
        {
            try
            {
                if (movies.Count > 0)
                {
                    foreach (var m in movies)
                    {
                        _context.Filmes.Add(m);
                        _context.SaveChanges();
                    }

                    _logger.LogInformation($"POST /Filmes cadastrados com Sucesso");
                }

                return CreatedAtAction(nameof(GetAllMoviesDB), new {movies}, movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST /Tarefa - Ocorreu um erro ao criar a tarefa");
                return StatusCode(500);
            }
        }
    }
}
