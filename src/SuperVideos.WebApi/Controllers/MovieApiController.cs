using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperVideos.Application.Contracts;
using SuperVideos.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperVideos.WebApi.Controllers
{
    /// <summary>
    /// Api para CRUD de Filmes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : Controller
    {

        protected readonly IMovieApp _movieApp;

        public MovieApiController(IMovieApp movieApp)
        {
            _movieApp = movieApp;
        }

        /// <summary>
        /// Realiza o cadastro de um Filme
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public  IActionResult Create([FromBody]MovieViewModel movie)
        {
            try
            {

                return Accepted(movie);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            try
            {
                return Ok(_movieApp.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
