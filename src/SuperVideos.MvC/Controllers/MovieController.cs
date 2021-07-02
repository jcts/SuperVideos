using Microsoft.AspNetCore.Mvc;
using SuperVideos.Application.Contracts;
using SuperVideos.Application.Models;
using System;

namespace SuperVideos.MvC.Controllers
{
    public class MovieController : Controller
    {
        protected readonly IMovieApp _movieApp;

        public MovieController(IMovieApp movieApp)
        {
            _movieApp = movieApp;
        }

        public IActionResult Index(int? page = 1)
        {
            var movies =  _movieApp.Pagination(page ?? 1, 10);

            return View(movies);
        }


        [HttpPost]
        public IActionResult SetAvailable(Guid id)
        {
            try
            {
                _movieApp.SetAvailable(id);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public IActionResult SetUnavailable(Guid id)
        {
            try
            {
                _movieApp.SetUnavailable(id);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult LoadSleeveImage(Guid movieId)
        {
            var movie = _movieApp.GetById(movieId);

            return movie == null || string.IsNullOrEmpty(movie.ContenType) ?
                File("images/film-not-found.png", "image/png") :
                File(movie.SleeveContent, movie.ContenType);
        }

        [HttpGet]
        public IActionResult Gallery([FromQuery]int page = 1, string param = "" )
        {
            try
            {
                var movies = _movieApp.Pagination(page, (int)Crosscutting.Constants.Config.MoviesPerPage);

                return View(movies);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _movieApp.Delete(id);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            try
            {
                var movie = _movieApp.GetById(id);

                return View(movie);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel movie)
        {
            try
            {
                _movieApp.Update(movie);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel movie)
        {
            try
            {
                _movieApp.Create(movie);

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
